# Oude resultaten weghalen
Remove-Item -Recurse -Force TestResults, CoverageRapport -ErrorAction SilentlyContinue

# Tests draaien en coverage meten
dotnet test --logger "trx;LogFileName=testresultaten.trx" --collect:"XPlat Code Coverage" --results-directory TestResults

# Rapport maken
reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"CoverageRapport" -reporttypes:"Html;TextSummary" -filefilters:"-*Program.cs;-*Migrations*" -classfilters:"-AspNetCoreGeneratedDocument*"

# Korte samenvatting laten zien
Get-Content CoverageRapport/Summary.txt


# Draaien doe je in de terminal (in de hoofdmap) met:
powershell -ExecutionPolicy Bypass -File .\metrics.ps1