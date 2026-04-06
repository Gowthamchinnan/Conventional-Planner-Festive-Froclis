$connStr = 'Server=.\SQLEXPRESS;Database=HBDB;Integrated Security=true;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)

try {
    $conn.Open()
    Write-Host "Connected to HBDB!" -ForegroundColor Green
    Write-Host ""
    
    $sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME"
    $cmd = New-Object System.Data.SqlClient.SqlCommand($sql, $conn)
    $reader = $cmd.ExecuteReader()
    
    Write-Host "Tables in HBDB:" -ForegroundColor Cyan
    $i = 0
    while ($reader.Read()) {
        $i++
        Write-Host "  $i. $($reader['TABLE_NAME'])"
    }
    $reader.Close()
    Write-Host ""
    Write-Host "Total: $i tables" -ForegroundColor Green
}
catch {
    Write-Host "Error: $_" -ForegroundColor Red
}
finally {
    $conn.Close()
}
