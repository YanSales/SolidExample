# 📚 Guia Prático de Princípios SOLID em .NET

Bem-vindos! 👋

Este repositório foi criado para ajudá-los a entender, de forma **prática e visual**, os 5 princípios SOLID que vão transformar a qualidade do código de vocês.

## 🎯 O que é SOLID?

SOLID é um acrônimo criado por Robert C. Martin (Uncle Bob) que representa 5 princípios fundamentais da programação orientada a objetos. Pense neles como as **"boas maneiras" do código** - seguindo-os, seu código fica mais limpo, testável e fácil de manter.

## 📖 Os 5 Princípios

### **S** - Single Responsibility Principle (Princípio da Responsabilidade Única)
> *"Uma classe deve ter apenas um motivo para mudar"*

**O problema:** Imagine uma classe `User` que salva no banco de dados, envia emails E valida dados. Se você mudar a forma de enviar email, precisa mexer na classe de usuário. Isso é perigoso!

**A solução:** Cada classe faz **apenas uma coisa**:
- `User` → Só guarda dados do usuário
- `UserRepository` → Só salva no banco
- `EmailService` → Só envia emails
- `UserValidator` → Só valida dados

**Por que isso importa?** Quando algo quebrar, você sabe exatamente onde procurar!

---

### **O** - Open/Closed Principle (Princípio Aberto/Fechado)
> *"Aberto para extensão, fechado para modificação"*

**O problema:** Você tem um sistema de descontos com vários `if/else`. Toda vez que criar um novo tipo de desconto, precisa **modificar** o código existente (arriscado!).

**A solução:** Use interfaces e polimorfismo! Crie novos tipos de desconto como **novas classes**, sem mexer nas antigas:
```csharp
var calculator = new DiscountCalculator(new VIPDiscount());
// Quer adicionar Black Friday? Só cria: new BlackFridayDiscount()
```

**Por que isso importa?** Código que funciona não deve ser mexido. Adicione funcionalidades sem risco de quebrar o que já existe!

---

### **L** - Liskov Substitution Principle (Princípio da Substituição de Liskov)
> *"Objetos filhos devem poder substituir seus pais sem quebrar o programa"*

**O problema:** Você tem uma classe `Bird` com método `Fly()`, mas um `Penguin` não voa! Se herdar de `Bird`, vai ter que lançar exceção no `Fly()`. Isso quebra o contrato!

**A solução:** Crie abstrações mais genéricas. Em vez de `Fly()`, use `Move()`:
- `Eagle.Move()` → voa
- `Penguin.Move()` → nada
- `Ostrich.Move()` → corre

**Por que isso importa?** Você pode tratar todos os objetos da mesma forma em loops e listas, sem surpresas desagradáveis!

---

### **I** - Interface Segregation Principle (Princípio da Segregação de Interfaces)
> *"Não force classes a implementar métodos que não vão usar"*

**O problema:** Interface gigante `IWorker` obriga um `Robot` a implementar `Eat()` e `Sleep()`. Robôs não comem nem dormem!

**A solução:** Crie interfaces pequenas e específicas:
- `IWorkable` → só `Work()`
- `IFeedable` → só `Eat()`
- `ISleepable` → só `Sleep()`

Agora `Human` implementa todas, mas `Robot` só implementa `IWorkable`!

**Por que isso importa?** Classes mais limpas, sem métodos inúteis jogando exceção.

---

### **D** - Dependency Inversion Principle (Princípio da Inversão de Dependência)
> *"Dependa de abstrações, não de implementações concretas"*

**O problema:** Sua classe `Notifier` cria um `EmailSender` dentro dela. Quer trocar para SMS? Tem que **reescrever** a classe!

**A solução:** Receba uma **interface** no construtor:
```csharp
var notifier = new Notifier(new EmailNotifier()); // Usa email
var notifier2 = new Notifier(new SMSNotifier());  // Usa SMS
```
A mesma classe funciona com qualquer tipo de notificação!

**Por que isso importa?** Flexibilidade máxima! Troque implementações sem mexer em nenhuma linha de código.

---

## 🚀 Como Rodar Este Projeto

### Pré-requisitos
- [.NET 6.0 SDK ou superior](https://dotnet.microsoft.com/download)

### Passo a Passo

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/seu-usuario/solid-examples.git
   cd solid-examples
   ```

2. **Rode o projeto:**
   ```bash
   dotnet run
   ```

3. **Observe a saída no console** mostrando cada princípio em ação! 🎉

---

## 📝 Estrutura do Código

```
📦 Program.cs
├── 🅂 Single Responsibility 
├── 🅞 Open/Closed 
├── 🅛 Liskov Substitution 
├── 🅘 Interface Segregation 
├── 🅓 Dependency Inversion 
└── ▶️ Main Program 
```

Cada seção tem:
- ❌ Exemplo **ERRADO** (como NÃO fazer)
- ✅ Exemplo **CORRETO** (a forma SOLID)

---

## 🎓 Exercícios para Praticar

Agora que você viu os exemplos, tente aplicar:

1. **S:** Pegue uma classe "Deus" (que faz muita coisa) em algum projeto seu e separe as responsabilidades

2. **O:** Identifique um `switch/case` ou vários `if/else` no seu código. Pode virar Strategy Pattern?

3. **L:** Você tem hierarquias de herança? Todas as subclasses realmente podem substituir a classe pai?

4. **I:** Suas interfaces têm muitos métodos? Alguma classe implementa métodos que não usa?

5. **D:** Você está criando objetos concretos dentro das classes? Tente usar injeção de dependência!

---

## 💡 Dicas do Professor

### "Mas professor, tenho que seguir TODOS sempre?"

Não seja dogmático! SOLID são **princípios**, não leis. Use quando fizer sentido:

- ✅ Projeto grande e complexo → SOLID salva sua vida
- ✅ Código que vai mudar muito → SOLID facilita manutenção
- ⚠️ Script simples de 50 linhas → Talvez seja overkill

### "Como saber quando estou violando um princípio?"

Pergunte-se:
- Tenho medo de mexer neste código? **(provavelmente violando S ou O)**
- Preciso mudar várias classes para adicionar uma feature? **(violando O ou D)**
- Testes quebram quando mudo implementações? **(violando D)**
- Classes têm métodos vazios ou que lançam exceção? **(violando I ou L)**

### "Por onde começo?"

1. **Comece com S** - É o mais intuitivo
2. **Depois D** - Muda completamente sua forma de pensar
3. **Os outros** vêm naturalmente com a prática

---

## 🌟 Recursos Adicionais

- 📖 [Clean Code - Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
- 🎥 [SOLID Principles Explained (YouTube)](https://www.youtube.com/results?search_query=solid+principles)
- 🔗 [Refactoring Guru - Design Patterns](https://refactoring.guru/design-patterns)

---

## 🤝 Contribuições

Encontrou um exemplo que pode ser melhorado? Quer adicionar mais casos de uso? **Pull requests são bem-vindos!**

1. Faça um Fork
2. Crie sua branch (`git checkout -b feature/exemplo-incrivel`)
3. Commit suas mudanças (`git commit -m 'Adiciona exemplo X'`)
4. Push para a branch (`git push origin feature/exemplo-incrivel`)
5. Abra um Pull Request

---

## 📜 Licença

Este projeto é livre para uso educacional. Compartilhe conhecimento! 🚀

---

## 👨‍🏫 Palavra Final

Lembrem-se: **código bom é código que outros conseguem entender**. SOLID não é sobre mostrar que você é inteligente, é sobre escrever código que seu "eu do futuro" (e seus colegas) vão agradecer.

Bons estudos e happy coding! 💻✨

---

**Dúvidas?** Abra uma [Issue](../../issues) e vamos conversar!

*"Any fool can write code that a computer can understand. Good programmers write code that humans can understand."* - Martin Fowler
