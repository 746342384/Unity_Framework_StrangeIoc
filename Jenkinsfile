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
                    
                    // Import the WSMan.Management module and create the WSMan drive
                    Import-Module Microsoft.WSMan.Management;
                    New-Item -Path WSMan:\localhost\Service -Name AllowUnencrypted -Value $true -Force | Out-Null
                    
                    // Set the TrustedHosts value
                    Set-Item -Path WSMan:\localhost\Client\TrustedHosts -Value $host -Force
                    
                    // Create a PowerShell credential object
                    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force
                    $credential = New-Object System.Management.Automation.PSCredential ($user, $securePassword)
                    
                    // Test the WSMan connection to the remote host
                    Test-WSMan -ComputerName $host -Credential $credential
                    
                    // Build the Unity project using PowerShell
                    $command = "${unityPath} -quit -batchmode -projectPath E:\\Project\\StrangeIoc -executeMethod BuildScript.PerformBuild -logfile E:\\Project\\StrangeIoc\\Build\\build.log -verbose"
                    Invoke-Command -ComputerName $host -Credential $credential -ScriptBlock { param($command) & pwsh.exe -Command $command } -ArgumentList $command
                }
            }
        }
    }
}

