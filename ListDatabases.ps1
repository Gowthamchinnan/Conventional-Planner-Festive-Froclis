$connStr = 'Server=.\SQLEXPRESS;Integrated Security=true;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)

try {
    $conn.Open()
    Write-Host "Connected to SQL Server!" -ForegroundColor Green
    Write-Host ""
    
    $sql = "SELECT name, state_desc FROM sys.databases ORDER BY name"
    $cmd = New-Object System.Data.SqlClient.SqlCommand($sql, $conn)
    $reader = $cmd.ExecuteReader()
    
    Write-Host "Databases on server:" -ForegroundColor Cyan
    while ($reader.Read()) {
        $dbName = $reader['name']
        $state = $reader['state_desc']
        $status = if ($state -eq 'ONLINE') { "[Online]" } else { "[Offline]" }
        Write-Host "  $dbName $status"
    }
    $reader.Close()
}
catch {
    Write-Host "Error: $_" -ForegroundColor Red
}
finally {
    $conn.Close()
}
