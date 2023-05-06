pipeline {
    agent {
        docker{
            image 'jenkins/jenkins'
            args '-v /var/run/docker.sock:/var/run/docker.sock -v /usr/bin/docker:/usr/bin/docker'
        }
    }
    stages {
        stage('Build Unity Project') {
            steps {
                script {
                    def unityPath = "/unity/unity-installation/2021.3.6f1c1/Editor/Unity"
                    sh "${unityPath} -quit -batchmode -projectPath unity/project -executeMethod BuildScript.PerformBuild -logfile"
                }
            }
        }
    }
}
