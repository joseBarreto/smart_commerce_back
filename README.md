# Smart Commerce Services
Publicação: [smart_commerce_services](https://smart-commerce-back.azurewebsites.net)


# Status Pipeline
[![Azure App Service - smart-commerce-back-br(Production), Build and deploy DotnetCore app](https://github.com/joseBarreto/smart_commerce_back/actions/workflows/main_smart-commerce-back.yml/badge.svg)](https://github.com/joseBarreto/smart_commerce_back/actions/workflows/main_smart-commerce-back.yml)

# Add Migration
Navegar ate a masta ./SmartCommerce.Infra.Data
Executar o seguinte comando
dotnet ef migrations add {Nome_migration} --startup-project ../SmartCommerce.Application/SmartCommerce.Application.csproj


# Update Database
Navegar ate a masta ./SmartCommerce.Infra.Data
Executar o seguinte comando
dotnet ef database update --startup-project ../SmartCommerce.Application/SmartCommerce.Application.csproj