# Added this file to call the API from vscode terminal
Clear
Invoke-RestMethod -Method get -Uri http://localhost:5073/weatherforecast | ConvertTo-Json 