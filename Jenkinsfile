pipeline {
    agent any
    stages {
        stage('Build Unity Project') {
            steps {
                script {
                    def unityPath = tool 'unity'
                    sshpass -p '989766' ssh Administrator@192.168.3.134 "${unityPath} -quit -batchmode -nographics -silent -crashes -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile"
                }
            }
        }
    }
}
