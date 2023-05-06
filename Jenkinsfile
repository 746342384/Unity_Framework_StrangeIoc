pipeline {
    agent 
    {
    docker{
    image 'unity:2021.3.6f1c1'
    args '-v E:\\Project\\StrangeIoc:\\unity\\project'
    }
    }
    stages {
        stage('Build Unity Project') {
            steps {
                script {
                    def unityPath = "D:\\Unity\\2021.3.6f1c1\\Editor\\Unity.exe"
                    sh "\"${unityPath}\" -quit -batchmode -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile"
                }
            }
        }
    }
}
