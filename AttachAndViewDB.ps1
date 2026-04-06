$connStr = 'Server=.\SQLEXPRESS;Integrated Security=true;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)

try {
    $conn.Open()
    Write-Host "Attaching HBDB database..." -ForegroundColor Yellow
    
    $mdfPath = "D:\Conventional Festive Frolics-20260406T103403Z-1-001\Conventional Festive Frolics\App_Data\HBDB.mdf"
    $ldfPath = "D:\Conventional Festive Frolics-20260406T103403Z-1-001\Conventional Festive Frolics\App_Data\HBDB_log.LDF"
    
    # Check if files exist
    if (-not (Test-Path $mdfPath)) {
        Write-Host "Error: Database file not found at $mdfPath" -ForegroundColor Red
        exit
    }
    
    $sql = "CREATE DATABASE HBDB ON PRIMARY (FILENAME = '$mdfPath') LOG ON (FILENAME = '$ldfPath') FOR ATTACH"
    $cmd = New-Object System.Data.SqlClient.SqlCommand($sql, $conn)
    $cmd.ExecuteNonQuery()
    
    Write-Host "Successfully attached HBDB database!" -ForegroundColor Green
    Write-Host ""
    
    # Now list tables
    $conn.ChangeDatabase("HBDB")
    $sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME"
    $cmd = New-Object System.Data.SqlClient.SqlCommand($sql, $conn)
    $reader = $cmd.ExecuteReader()
    
    Write-Host "Tables in HBDB:" -ForegroundColor Cyan
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
