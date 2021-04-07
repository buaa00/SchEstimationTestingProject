#!/bin/bash

dotnet ef database update -s ../src/Apps/WebApi -p ../src/Infrastructure -c EfCoreDbContext -- --environment Development