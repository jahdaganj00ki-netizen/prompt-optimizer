#!/bin/bash
set -e

echo "Building Prompt Optimizer..."

cd PromptOptimizer

echo "Restoring NuGet packages..."
nuget restore

echo "Building release binary..."
msbuild PromptOptimizer.csproj \
  /p:Configuration=Release \
  /p:Platform=x64 \
  /p:TargetFrameworkVersion=v4.7.2

echo "Merging dependencies into single .exe..."
ilmerge /out:PromptOptimizer.exe \
  bin/Release/PromptOptimizer.exe \
  bin/Release/Newtonsoft.Json.dll \
  bin/Release/EntityFramework.dll \
  bin/Release/System.Data.SQLite.dll \
  bin/Release/log4net.dll \
  /t:winexe

echo "Build complete!"
echo "Portable executable: PromptOptimizer/PromptOptimizer.exe"
