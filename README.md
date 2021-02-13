dotnet tool install --global dotnet-ef

dotnet ef migrations add "InitialCreate" --startup-project ../Demo.Api/

dotnet ef database update --startup-project ../Demo.Api/

dotnet ef migrations remove --startup-project ../Demo.Api/


npx -p @angular/cli@10.2.2 ng new angular2app

ng add ngx-bootstrap 
npm i font-awesome
npm i bootswatch
npm i ngx-toastr

"./node_modules/bootstrap/dist/css/bootstrap.min.css",
"./node_modules/ngx-bootstrap/datepicker/bs-datepicker.css",
"./node_modules/bootswatch/dist/cosmo/bootstrap.css",
"./node_modules/font-awesome/css/font-awesome.css",
"./node_modules/ngx-toastr/toastr.css",
"src/styles.css"