pipeline {
    agent any
    stages {
        stage('Build Unity Project') {
            steps {
                script {
                    def unityPath = tool 'unity'
                    def password = '989766'
                    def user = 'Administrator'
                    def host = '192.168.3.134'
                    sh """
                        sshpass -p '${password}' ssh ${user}@${host} "/opt/microsoft/powershell/pwsh -c '${unityPath} -quit -batchmode -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile E:\\Project\\StrangeIoc\\Build\\build.log -verbose'"
                    """
                }
            }
        }
    }
}
