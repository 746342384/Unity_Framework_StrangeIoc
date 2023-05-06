pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                script {
                    if (isUnix())
                    {
                        sh 'echo Building Unity project...'
                    }
                    else 
                    {
                        bat 'echo Building Unity project...'
                    }
                }
                unity3d command: 'build', platforms: 'Windows', installation: 'D:\\Unity\\2021.3.6f1c1\\Editor\\<2021.3.6f1c1>'
            }
        }
    }
}
