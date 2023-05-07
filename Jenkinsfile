pipeline {
    agent {
        docker{
            image '976459dc87b041c45ffcd1a46086bc0e0681e3affb3261311cc0ad83f3066a11'
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
