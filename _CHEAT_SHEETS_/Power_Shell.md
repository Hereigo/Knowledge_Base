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

# ... CERTIFICATE REMOVE :

cd Cert:\LocalMachine\Root

C:\TELEO\Setup\makecert -pe -is Root -ir LocalMachine -in "Certificate-Issuer-Name-Here" -n CN="Cert-Issued-To-Name" -eku 1.3.6.1.5.5.7.3.1 -ss Root -sr localmachine -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12 
echo "."
echo ". Certificate Cert-Issued-To-Name added."

# ... CERTIFICATE REMOVE :

cd Cert:\LocalMachine\Root

Get-ChildItem | Where Subject -like "*CN=Cert-Issued-To-Name"
Get-ChildItem | Where Subject -like "*CN=Cert-Issued-To-Name" | Remove-Item
echo "."
echo ". Certificate Cert-Issued-To-Name removed."

```