using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Framework.framework.addressable.api;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// 检测更新并下载资源
public class AddressableDownload : IAddressableDownload
{
    private AsyncOperationHandle downloadDependencies;

    /// <summary>
    /// 下载多个文件列表
    /// PS: 一个组内填写一个资源Key即可，下载时会按照资源组进行下载
    /// </summary>
    private readonly List<string> downLoadKeyList = new()
    {
        "Common", "Group1"
    };

    // 当前下载文件索引
    private int downLoadIndex;

    // 下载完成文件个数
    private int downLoadCompleteCount;

    // 下载每组资源大小
    private readonly List<long> downLoadSizeList = new();

    // 下载资源总大小
    private long downLoadTotalSize;

    // 当前下载大小
    private float curDownLoadSize;

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

        // 清理缓存
        Caching.ClearCache();

        for (var i = 0; i < downLoadKeyList.Count; i++)
        {
            var size = Addressables.GetDownloadSizeAsync(downLoadKeyList[i]);
            Debug.Log("获取下载内容大小：" + size.Result);
            downLoadSizeList.Add(size.Result);
            downLoadTotalSize += size.Result;
        }

        if (downLoadTotalSize <= 0)
        {
            Debug.LogError("无可预下载内容~");
            return;
        }


        for (var i = downLoadIndex; i < downLoadKeyList.Count; i++)
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
}