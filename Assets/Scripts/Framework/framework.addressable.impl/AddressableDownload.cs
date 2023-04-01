using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Framework.framework.addressable.api;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// 检测更新并下载资源
public class AddressableDownload : IAddressableDownload
{
    #region Download

    private AsyncOperationHandle downloadDependencies;
    private int downLoadIndex;
    private int downLoadCompleteCount;
    private readonly List<long> downLoadSizeList = new();
    private long downLoadTotalSize;
    private float curDownLoadSize;

    #endregion

    public IEnumerable<string> GetGroups()
    {
        var groupNamesObject = Resources.Load<AddressableGroupNames>("AddressableGroupNames");
        return groupNamesObject.GroupNames;
    }


    /// <summary>
    /// 预下载
    /// </summary>
    /// <param name="key">资源包key</param>
    /// <returns></returns>
    public async UniTask StartPreload()
    {
        downLoadIndex = 0;
        Debug.Log("开始下载");

        // 初始化 --> 加载远端的配置文件
        await Addressables.InitializeAsync();

        var downLoadKeyList = GetGroups().ToArray();
        for (var i = 0; i < downLoadKeyList.Length; i++)
        {
            var size = Addressables.GetDownloadSizeAsync(downLoadKeyList[i]);
            Debug.Log("获取下载内容大小：" + size.Result);
            downLoadSizeList.Add(size.Result);
            downLoadTotalSize += size.Result;
        }

        if (downLoadTotalSize <= 0)
        {
            Debug.Log("无可预下载内容~");
        }
        else
        {
            for (var i = downLoadIndex; i < downLoadKeyList.Length; i++)
            {
                downloadDependencies = Addressables.DownloadDependenciesAsync(downLoadKeyList[i]);

                while (!downloadDependencies.IsDone)
                {
                    if (downloadDependencies.Status == AsyncOperationStatus.Failed)
                    {
                        downLoadIndex = i;
                        Debug.Log("下载失败，请重试...");
                        return;
                    }

                    curDownLoadSize = 0;
                    for (var j = 0; j < downLoadSizeList.Count; j++)
                    {
                        if (j < downLoadCompleteCount)
                        {
                            curDownLoadSize += downLoadSizeList[j];
                        }
                    }

                    if (downLoadCompleteCount < downLoadSizeList.Count - 1)
                    {
                        curDownLoadSize += downloadDependencies.GetDownloadStatus().Percent;
                    }

                    var percent = curDownLoadSize * 1.0f / downLoadTotalSize;

                    if (percent < 1)
                    {
                        Debug.Log($"当前文件下载大小 {curDownLoadSize} 总下载大小 {downLoadTotalSize}");
                    }

                    await UniTask.Delay(100);
                }

                downLoadCompleteCount = i + 1;
            }

            Debug.Log("下载完成 释放句柄");
            // 下载完成释放句柄
            Addressables.Release(downloadDependencies);
        }

        await UpdateResources();
    }

    private async UniTask UpdateResources()
    {
        Debug.Log("检测资源是否需要更新");
        // 检查远程资源更新
        var checkHandle = Addressables.CheckForCatalogUpdates(false);
        await checkHandle;

        switch (checkHandle.Status)
        {
            case AsyncOperationStatus.None:
                Debug.Log("检测资源更新完成，没有资源需要更新");
                return;
            case AsyncOperationStatus.Failed:
                Debug.LogError("检测资源更新失败");
                return;
            case AsyncOperationStatus.Succeeded:
                Debug.Log("检测资源更新完成");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        // 如果有更新，则下载新资源
        if (checkHandle.Result.Count > 0)
        {
            foreach (var s in checkHandle.Result)
            {
                Debug.Log($"有资源需要更新：{s}");
            }

            var nowLoadHandle = Addressables.UpdateCatalogs(checkHandle.Result, false);
            var deps = new List<AsyncOperationHandle>();
            nowLoadHandle.GetDependencies(deps);

            while (!nowLoadHandle.IsDone)
            {
                if (nowLoadHandle.Status == AsyncOperationStatus.Failed)
                {
                    Debug.Log("资源更新失败，请重试...");
                    return;
                }

                foreach (var asyncOperationHandle in deps)
                {
                    Debug.Log($"更新资源：{asyncOperationHandle.DebugName}，资源需要进度：{asyncOperationHandle.PercentComplete}");
                }

                await UniTask.Delay(100);
            }

            Debug.Log($"资源更新完成，释放句柄");
            Addressables.Release(checkHandle);
        }
        else
        {
            Debug.Log("没有资源需要更新");
        }
    }
}