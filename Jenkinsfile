pipeline {
    agent any
    environment {PATH = "${tool 'unity'}/Editor:${env.PATH}"}
    stages {
    stage('Set PowerShell Path') {
                steps {
                    script {
                            env.PATH = "/opt/microsoft/powershell:${env.PATH}"
                        }
                    }
                }
        stage('Build Unity Project') {
            steps {
                script {
                    def password = '989766'
                    def user = 'Administrator'
                    def host = '192.168.3.134'
                    def unityPath = tool 'unity'
                    env.PATH = "/opt/microsoft/powershell:${env.PATH}"
                    sshagent(credentials: ['winjet']) {
                        pwsh """
                            sshpass -p $password ssh $user@$host ${unityPath} -quit -batchmode -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile E:\\Project\\StrangeIoc\\Build\\build.log -verbose 
                        """
                    }
                }
            }
        }
    }
}


