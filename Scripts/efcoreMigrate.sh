#!/bin/bash

dotnet ef migrations add InitialCreate -s ../src/Apps/WebApi -p ../src/Infrastructure -c EfCoreDbContext