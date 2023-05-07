pipeline {
    agent any
    environment {
            PATH_POWERSHELL = "/opt/microsoft/powershell"
        }
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
              def unityPath = tool 'unity'
              def password = "989766"
              def user = "Administrator"
              def host = "192.168.3.134"
              env.PATH = "/opt/microsoft/powershell:${env.PATH}"
              pwsh """
                \$Username = '${user}'
                \$Password = '${password}' | ConvertTo-SecureString -AsPlainText -Force
                \$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList \$Username, \$Password
                Test-WSMan -ComputerName '${host}' -Credential \$Credential
                \$Command = '${unityPath} -quit -batchmode -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile E:\\Project\\StrangeIoc\\Build\\build.log -verbose'
                Invoke-Command -ComputerName '${host}' -Credential \$Credential -ScriptBlock {
                  param(\$Command)
                  Invoke-Expression \$Command
                } -ArgumentList \$Command
              """
            }
          }
        }
    }
}

