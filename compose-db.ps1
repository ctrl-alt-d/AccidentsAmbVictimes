Param(
  [string]$Db = 'postgres',
  [string]$ConnectionString,
  [Parameter(ValueFromRemainingArguments = $true)]
  [string[]]$ComposeArgs
)

function Show-Help {
  @'
Usage: ./compose-db.ps1 [-Db postgres|mysql|sqlserver] [-ConnectionString <conn>] [docker compose args...]

Examples:
  ./compose-db.ps1 up --build
  ./compose-db.ps1 -Db mysql up --build
  ./compose-db.ps1 -Db sqlserver up
  ./compose-db.ps1 -Db mysql -ConnectionString "Server=mysql;Port=3306;User=root;Password=123456;Database=victimes" up --build

Notes:
  - Estableix variables d'entorn DB_BRAND i CONNECTION_STRING.
  - Usa profiles per limitar el servei.
'@
}

if ($Db -in @('-h','--help','help')) { Show-Help; exit 0 }

if ($Db -notin @('postgres','mysql','sqlserver')) {
  Write-Error "Gestor no suportat: $Db (usa postgres|mysql|sqlserver)"; exit 1
}

$profileArgs = @()
if ($Db -ne 'postgres') { $profileArgs += @('--profile', $Db) }

$env:DB_BRAND = $Db
if ($ConnectionString) { $env:CONNECTION_STRING = $ConnectionString }

docker compose $profileArgs $ComposeArgs
