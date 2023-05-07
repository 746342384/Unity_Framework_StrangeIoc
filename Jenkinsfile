node {
    def unityPath = tool 'unity'
    def password = "989766"
    def user = "Administrator"
    def host = "192.168.3.134"

    stage('Build') {
        sh """
            sshpass -p '${password}' ssh ${user}@${host} "${unityPath} -quit -batchmode -nographics -silent -crashes -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile"
        """
    }
}

