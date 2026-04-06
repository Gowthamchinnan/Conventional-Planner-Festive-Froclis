$connStr = 'Server=.\SQLEXPRESS;AttachDbFilename=D:\Conventional Festive Frolics-20260406T103403Z-1-001\Conventional Festive Frolics\App_Data\HBDB.mdf;Integrated Security=true;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)

try {
    $conn.Open()
    Write-Host "Connected to HBDB!" -ForegroundColor Green
    Write-Host ""
    
    # Get all table names
    $sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME"
    $cmd = New-Object System.Data.SqlClient.SqlCommand($sql, $conn)
    $reader = $cmd.ExecuteReader()
    
    Write-Host "Tables in HBDB:" -ForegroundColor Cyan
    Write-Host "===============" -ForegroundColor Cyan
    $count = 0
    while ($reader.Read()) {
        $count++
        $tableName = $reader['TABLE_NAME']
        Write-Host "  $count. $tableName"
    }
    $reader.Close()
    Write-Host ""
    Write-Host "Total: $count tables" -ForegroundColor Green
}
catch {
    Write-Host "Error: $_" -ForegroundColor Red
}
finally {
    $conn.Close()
}
