pipeline {
    agent any
    environment {
        PATH = "${tool 'unity'}/Editor:${env.PATH}"
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
                    def password = 'password'
                    def user = 'user'
                    def host = '192.168.3.134'
                    def unityPath = tool 'unity'

                    env.PATH = "/opt/microsoft/powershell:${env.PATH}"
                    pwsh """
                        Import-Module Microsoft.WSMan.Management;
                        New-Item -Path WSMan:\\localhost\\Service -Name AllowUnencrypted -Value \$true -Force | Out-Null
                    
                        Set-Item -Path WSMan:\\localhost\\Client\\TrustedHosts -Value $host -Force
                    
                        \$securePassword = ConvertTo-SecureString $password -AsPlainText -Force
                        \$credential = New-Object System.Management.Automation.PSCredential ('$user', \$securePassword)
                    
                        Test-WSMan -ComputerName $host -Credential \$credential
                    
                        \$command = "${unityPath} -quit -batchmode -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile E:\\Project\\StrangeIoc\\Build\\build.log -verbose"
                        Invoke-Command -ComputerName $host -Credential \$credential -ScriptBlock { param(\$command) & pwsh.exe -Command \$command } -ArgumentList \$command
                    """
                }
            }
        }
    }
}
