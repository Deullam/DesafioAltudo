# DesafioAltudo

#### How to use:
 - É necessário a última versão no .Net Core SDK
 - Se tiver a versão do visual studio 2019 é mais fácil para rodar, apenas abrindo a solução e a abrindo ela no servido IIS
 - A API já tem o swagger que pode ser acessado na url: /swagger/index.html

Link para download do .Net: https://dot.net/core

##### Inside the server folder run the commands: 

- dotnet restore DesafioAltudo.API/DesafioAltudo.API.csproj
- dotnet build DesafioAltudo.API/DesafioAltudo.API.csproj -c Release -o /app/build
- dotnet publish DesafioAltudo.API/DesafioAltudo.API.csproj -c Release -o /app/publish
- cd DesafioAltudo.API\bin\Release\net5.0\
- dotnet DesafioAltudo.API.dll

Server will be running on port: 5000 and 5001


#### Docker
- docker build -t desafioaltudo -f DesafioAltudo.API\Dockerfile .
- docker run -d --rm --name desafioaltudo-container desafioaltudo -p 5000:5000


#### Consuming the API: Postman

- http://localhost:5001/page

 - Object Json:
 - { "Url": "http://www.google.com" }



### Example:
![image](https://user-images.githubusercontent.com/39167458/126337957-965f550b-1c23-47aa-b0cf-93ba9b0aa7a4.png)
