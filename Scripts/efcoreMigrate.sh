#!/bin/bash

dotnet ef migrations add $1 -s ../src/Apps/WebApi -p ../src/Infrastructure -c EfCoreDbContext