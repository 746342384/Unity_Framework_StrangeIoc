pipeline {
    agent any
    stages {
        stage('Build Unity Project') {
            steps {
                script {
                    def unityPath = tool 'Unity2021'
                    sh "${unityPath}/Editor/Unity -quit -batchmode -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile"
                }
            }
        }
    }
}
