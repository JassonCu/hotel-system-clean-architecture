#!/usr/bin/env bash
set -e

# Wait for a service to be available
host="$1"
shift
cmd="$@"

until nc -z "$host" 1433; do
  >&2 echo "SQL Server is unavailable - sleeping"
  sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $cmd


# Please exect the follow command to run this script
# chmod +x wait-for-it.sh
