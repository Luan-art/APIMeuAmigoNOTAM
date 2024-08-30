# Documentação de Rotas - APIMeuAmigoNotam

### 1. Health checker
 
- **Endpoint**: 
![image](https://github.com/user-attachments/assets/8b109989-38fe-4a6f-a524-e2c150405144)

- **Descrição**: Checa a saúde da aplicação.
  
- **Exemplo de Resposta**:
![image](https://github.com/user-attachments/assets/1196ebec-9d8b-4d7f-827f-3dbbe9cd5fb0)


### 2. GetAllNotams
 
- **Endpoint**: 
![image](https://github.com/user-attachments/assets/dd507e1d-91e2-4307-a827-1847ebfa9050)

- **Descrição**: Lista todos os Natam salvos no Banco de Dados
  
- **Exemplo de Resposta**:
![image](https://github.com/user-attachments/assets/56768f55-0897-459a-9ef1-b04785c58700)


### 3. GetNotamById
 
- **Endpoint**: 
![image](https://github.com/user-attachments/assets/0eb1795b-8b26-4ddf-bd2d-39c4d53b98ca)

- **Descrição**: Encontra um Notam atráves de um ID.
  
- **Exemplo de Resposta**:
![image](https://github.com/user-attachments/assets/aa1fcbd4-c8a0-4df8-aa22-948eedd21abe)


### 4. CreateNotam
 
- **Endpoint**: 
![image](https://github.com/user-attachments/assets/b8cdcd50-79c6-458e-97d1-16c3700b1ef3)

- **Descrição**: Adcionar um Novo Notam ao Banco de dados.
- **Exemplo de Body**:
- ![image](https://github.com/user-attachments/assets/7665ddf5-8377-45af-8a8a-8d4b8b3977fd)
  
- **Exemplo de Resposta**:
![image](https://github.com/user-attachments/assets/72f0e834-9403-4831-946e-7e97bad2b60d)

### 5. GetIdsIfExperid
 
- **Endpoint**: 
![image](https://github.com/user-attachments/assets/ff9f7c9a-c84d-482c-94d2-d234d6e477b7)

- **Descrição**: Recupera Ids de Notams cujo a data atual ultrapassou a data em que o Notam Expira.
  
- **Exemplo de Resposta**:
![image](https://github.com/user-attachments/assets/a086d11a-4496-48e8-bf37-a0f3741eb0d7)

### 6. GetIsExperid
 
- **Endpoint**: 
![image](https://github.com/user-attachments/assets/9e903813-9267-4687-ab48-fd86ef8c9f4f)

- **Descrição**: Recupera os Notam Experidos ou não dependendo do último valor no endpoint (true ou false)
  
- **Exemplo de Resposta**:
![image](https://github.com/user-attachments/assets/8351b3d2-c7f3-40b3-a161-79cf7c6aa2b7)

### 7. UpdateExperid

- **Endpoint**: 
![image](https://github.com/user-attachments/assets/8d41b018-bf73-451b-92a3-82f2691b6b8c)

- **Descrição**: Modifica o valor boleano isExperid 
  
- **Exemplo de Resposta**:
![image](https://github.com/user-attachments/assets/0c32ff13-85bb-40aa-9b3b-c79a4e4e4ad2)

### 8. DeleteNotamByID

- **Endpoint**: 
![image](https://github.com/user-attachments/assets/3700b31e-2631-4f84-9d4e-1464dcefac26)

- **Descrição**: Deleta um registro Notam do Banco de dado 
  
- **Exemplo de Resposta**:
  Status Ok

### 7. UpdateNotam

- **Endpoint**: 
![image](https://github.com/user-attachments/assets/70b909c6-7a5e-4684-ab5f-bc9868d28bdf)

- **Descrição**: Atualiza os Dados de uma Notam 
- **Exemplo de Body**:
![image](https://github.com/user-attachments/assets/3b912c5d-1d07-4beb-bc33-e0b6d508f039)
  
- **Exemplo de Resposta**:
![image](https://github.com/user-attachments/assets/d2a74ec5-bff2-49ce-9672-68e2bb8d965e)
