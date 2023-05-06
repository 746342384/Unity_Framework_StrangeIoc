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
                bat 'echo Building Unity project...'
                unity3d command: 'build', platforms: 'Windows'
            }
        }
    }
}
