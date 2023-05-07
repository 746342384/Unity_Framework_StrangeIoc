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
                    def unityPath = tool 'unity'
                    sh "${unityPath} -quit -batchmode -nographics -silent -crashes -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile"
                }
            }
        }
    }
}
