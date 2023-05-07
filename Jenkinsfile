pipeline {
    agent any
    environment {
        PATH = "${tool 'unity'}/Editor:${env.PATH}"
    }
    stages {
        stage('Build Unity Project') {
            steps {
                script {
                    def password = 'password'
                    def user = 'user'
                    def host = '192.168.3.134'
                    def unityPath = tool 'unity'

                    sshagent(credentials: ['winjet']) {
                        sh """
                            # Build the Unity project using PowerShell on the remote Windows host
                            ssh $user@$host pwsh.exe -Command \"
                                \$command = '${unityPath} -quit -batchmode -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile E:\\Project\\StrangeIoc\\Build\\build.log -verbose'
                                & $command
                            \"
                        """
                    }
                }
            }
        }
    }
}

