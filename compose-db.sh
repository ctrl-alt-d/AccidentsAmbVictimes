#!/usr/bin/env bash
set -euo pipefail

show_help() {
  cat <<'EOF'
Usage: ./compose-db.sh [--db postgres|mysql|sqlserver] [--connection <connString>] [docker compose args...]

Examples:
  ./compose-db.sh up --build                # Postgres per defecte
  ./compose-db.sh --db mysql up --build     # MySQL
  ./compose-db.sh mysql up -d               # Forma curta (primer arg és el gestor)
  ./compose-db.sh --db sqlserver up         # SQL Server
  ./compose-db.sh --db mysql --connection "Server=mysql;Port=3306;User=root;Password=123456;Database=victimes" up --build

Notes:
  - Exporta DB_BRAND i (si s'indica) CONNECTION_STRING abans d'invocar "docker compose".
  - Usa profiles del docker-compose per engegar només el servei corresponent.
EOF
}

DB="postgres"
CONNECTION=""

REMAINING=()

if [[ $# -eq 0 ]]; then
  show_help
  exit 0
fi

while [[ $# -gt 0 ]]; do
  case "$1" in
    --db)
      shift
      DB="${1:-}"
      [[ -z "$DB" ]] && { echo "--db necessita un valor" >&2; exit 1; }
      ;;
    mysql|postgres|sqlserver)
      # Forma curta: primer arg és el gestor
      DB="$1"
      ;;
    --connection)
      shift
      CONNECTION="${1:-}"
      [[ -z "$CONNECTION" ]] && { echo "--connection necessita un valor" >&2; exit 1; }
      ;;
    -h|--help)
      show_help
      exit 0
      ;;
    *)
      REMAINING+=("$1")
      ;;
  esac
  shift || true
done

case "$DB" in
  postgres|mysql|sqlserver) ;;
  *) echo "Gestor no suportat: $DB (usa postgres|mysql|sqlserver)" >&2; exit 1 ;;
esac

PROFILE_ARGS="--profile $DB"

export DB_BRAND="$DB"
if [[ -n "$CONNECTION" ]]; then
  export CONNECTION_STRING="$CONNECTION"
fi

exec docker compose $PROFILE_ARGS "${REMAINING[@]}"
