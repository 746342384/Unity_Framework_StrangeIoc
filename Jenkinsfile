pipeline {
    agent any
    environment {
        REMOTE_HOST = "192.168.3.134"
        REMOTE_USER = "Administrator"
        REMOTE_PASSWORD = "989766"
        POWERSHELL_PATH = "/opt/microsoft/powershell/7/pwsh"
    }
    stages {
        stage('Build Unity Project') {
            steps {
                withEnv(["PATH+POWERSHELL=${POWERSHELL_PATH}"]) {
                    script {
                        def unityPath = tool 'unity'
                        def psCommand = """
                            \$Username = '${env.REMOTE_USER}'
                            \$Password = '${env.REMOTE_PASSWORD}' | ConvertTo-SecureString -AsPlainText -Force
                            \$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList \$Username, \$Password

                            # configure winrm
                            Set-Item -Path WSMan:\\localhost\\Service\\AllowUnencrypted -Value \$true -Force
                            Set-Item -Path WSMan:\\localhost\\Client\\TrustedHosts -Value ${env.REMOTE_HOST} -Force

                            # test winrm
                            Test-WSMan -ComputerName ${env.REMOTE_HOST} -Credential \$Credential

                            # run unity build
                            \$Command = '${unityPath} -quit -batchmode -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile E:\\Project\\StrangeIoc\\Build\\build.log -verbose'
                            Invoke-Command -ComputerName ${env.REMOTE_HOST} -Credential \$Credential -ScriptBlock {
                                param(\$Command)
                                Invoke-Expression \$Command
                            } -ArgumentList \$Command
                        """
                        pwsh(returnStdout: true, script: psCommand)
                    }
                }
            }
        }
    }
}
