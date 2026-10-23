#!/usr/bin/env bash
# Builds a self-contained EnemizerCLI.Core package for each runtime and tars it.
#
#   tools/publish.sh [RID...]      (default: linux-x64 linux-arm64 osx-x64 osx-arm64)
#
# Each dist/<rid>.tar.gz unpacks with EnemizerCLI.Core and its data files
# (sprites/, tiles/, enemizerBasePatch.json, ...) at the top level, the same
# layout as the old 2mb-rom release that alttpr's composer.json installs.
set -euo pipefail
cd "$(dirname "$0")/.."

rids=("$@")
[ ${#rids[@]} -gt 0 ] || rids=(linux-x64 linux-arm64 osx-x64 osx-arm64)

for rid in "${rids[@]}"; do
    out="dist/$rid"
    rm -rf "$out"
    dotnet publish EnemizerCLI.Core/EnemizerCLI.Core.csproj -c Release -r "$rid" \
        --self-contained -p:PublishSingleFile=true -p:DebugType=none -o "$out"
    tar -czf "dist/$rid.tar.gz" -C "$out" .
done
