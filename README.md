# User Manage API

Bem-vindo ao repositório do projeto **User Manage API**! Este projeto é uma API em .NET Core que oferece recursos incríveis para você começar a desenvolver.

## Configuração do Ambiente

### Configuração da Conexão com o Banco de Dados

1. No arquivo `appsettings.json`, localize a seção `ConnectionStrings`:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server='SEU_SERVIDOR'; Database='SEU_BANCO_DE_DADOS';User Id='SEU_USUARIO';Password='SUA_SENHA'; TrustServerCertificate='true'"
   }
   ```

   - Substitua `'SEU_SERVIDOR'`, `'SEU_BANCO_DE_DADOS'`, `'SEU_USUARIO'` e `'SUA_SENHA'` com as configurações apropriadas do seu servidor de banco de dados.

### Executando as Migrações do Banco de Dados

2. Abra um terminal na raiz do projeto e execute o seguinte comando para recriar o banco de dados:

   ```bash
   dotnet ef migrations add NomeDaMigracao
   dotnet ef database update
   ```

   Isso criará uma nova migração com o nome especificado e atualizará o banco de dados para refletir essa nova migração.

### Autenticação e Autorização

3. Esta API utiliza autenticação baseada em token. Para acessar os endpoints protegidos, você precisa obter um token de acesso válido através do endpoint de login.

   - Todos os endpoints, exceto o de login, exigem que você inclua o token JWT no cabeçalho de autorização da seguinte maneira:

     ```plaintext
     Authorization: Bearer SeuTokenJWT
     ```

   - Sem um token válido, você não conseguirá acessar os endpoints protegidos da API.

### Credenciais Padrão do Usuário

4. Após as migrações, um usuário padrão será criado automaticamente:

   - **Email:** admin@example.com
   - **Senha:** AdminPassword123!

   Essas credenciais permitem acesso inicial à aplicação para fins de desenvolvimento.

## Testando a API

Para testar os endpoints da API, recomendamos o uso da coleção do Postman disponível na documentação. Siga as etapas abaixo para importar e configurar a coleção:

### Importando a Coleção do Postman

1. Baixe a [collection do Postman](./postman/CRUD UserManager.postman_collection.json) deste repositório.

2. Abra o Postman e clique em **Import** no canto superior esquerdo.

3. Selecione o arquivo JSON que você baixou (`CRUD UserManager.postman_collection.json`).

4. Após importar, você verá a coleção `CRUD UserManager` no painel esquerdo do Postman.

### Configurando Variáveis de Ambiente (Opcional)

1. No Postman, clique no ícone de engrenagem ao lado da coleção importada e selecione **Edit**.

2. Clique na aba **Variables**.

3. Configure as variáveis de ambiente de acordo com seu ambiente local (por exemplo, `baseUrl` para `http://localhost:5000/api`).

### Executando os Testes

1. Com a coleção importada e variáveis configuradas, você pode expandir os folders da coleção para ver os endpoints disponíveis.

2. Cada endpoint possui métodos HTTP correspondentes (GET, POST, PUT, DELETE) que você pode testar clicando no botão **Send**.

3. Verifique as respostas da API para garantir que tudo está funcionando conforme esperado.

---

Com essas instruções, você deve ser capaz de configurar seu ambiente local, executar as migrações do banco de dados desde o início, entender a autenticação via token e começar a explorar e testar os recursos da sua API usando o Postman. Se precisar de mais ajuda, consulte a documentação do projeto.

**Divirta-se desenvolvendo com Meu Projeto!** 🚀

---
