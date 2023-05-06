pipeline {
    agent {
        docker{
            image 'jenkins/jenkins:latest'
        }
    }
    stages {
        stage('Build Unity Project') {
            steps {
                script {
                    def unityPath = "/unity/unity-installation/2021.3.6f1c1/Editor/Unity.exe"
                    sh "${unityPath} -quit -batchmode -projectPath unity/project -executeMethod BuildScript.PerformBuild -logfile"
                }
            }
        }
    }
}
