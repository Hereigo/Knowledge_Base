```powershell
# WRITE FILENAME AS A COMMENT INTO EVERY FILE.SQL IN THE DIRECTORY :

#@("--nameofSP","") +  (Get-Content -path .\procAcquisitionsCampaignsSet.proc.sql) | Set-Content -path.\procAcquisitionsCampaignsSet.proc.sql
#Get-Content -path .\procAcquisitionsCampaignsSet.proc.sql

$Directory="C:\Users\USER-NAME\source\PowerShell_Test"

Get-ChildItem $Directory -Filter "*.sql" `
    | Foreach-Object { `
        "--" + $_.Name + "`r`n" + (get-content $_) `
        | Out-File $_;  `
        Move-Item -Path $_ -Destination $Directory `
    }

# ...



```