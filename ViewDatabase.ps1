# PowerShell Script to View Database Tables and Data

$connectionString = 'Server=.\SQLEXPRESS;Database=HBDB;Integrated Security=true;'
$connection = New-Object System.Data.SqlClient.SqlConnection
$connection.ConnectionString = $connectionString

try {
    $connection.Open()
    Write-Host "✓ Connected to HBDB database successfully!" -ForegroundColor Green
    Write-Host ""
    
    # Get all table names
    $query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME"
    $command = New-Object System.Data.SqlClient.SqlCommand($query, $connection)
    $reader = $command.ExecuteReader()
    
    Write-Host "Tables in HBDB database:" -ForegroundColor Yellow
    Write-Host "========================" -ForegroundColor Yellow
    
    $tables = @()
    while ($reader.Read()) {
        $tableName = $reader[0]
        $tables += $tableName
        Write-Host "  $($tables.Count). $tableName"
    }
    
    $reader.Close()
    Write-Host ""
    Write-Host "Total tables: $($tables.Count)" -ForegroundColor Cyan
    Write-Host ""
    
    # Get row counts for each table
    Write-Host "Row counts:" -ForegroundColor Yellow
    Write-Host "===========" -ForegroundColor Yellow
    
    foreach ($table in $tables) {
        $countQuery = "SELECT COUNT(*) FROM [$table]"
        $countCommand = New-Object System.Data.SqlClient.SqlCommand($countQuery, $connection)
        $count = $countCommand.ExecuteScalar()
        Write-Host "  $table : $count rows"
    }
    
} catch {
    Write-Host "❌ Error: $_" -ForegroundColor Red
} finally {
    $connection.Close()
    Write-Host ""
    Write-Host "Connection closed." -ForegroundColor Gray
}
