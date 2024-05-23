using ChainOfResponsibilities;
using ChainOfResponsibilities.DB;
using ChainOfResponsibilities.Handlers;
using Newtonsoft.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;


AddNameUserHandler addNameUserHandler = new AddNameUserHandler();
AddSurnameHandler addSurnameHandler = new AddSurnameHandler();
AddAgeUserHandler addAgeUserHandler = new AddAgeUserHandler();
AddAccountNumberUserHandler addAccountNumberUserHandler = new AddAccountNumberUserHandler();
AddPincodeUserHandler addPincodeUserHandler = new AddPincodeUserHandler();
AddNewUserHandler addNewUserHandler = new AddNewUserHandler();
FindAccountNumberHandler findAccountNumberHandler = new FindAccountNumberHandler();
FindPinCodeHandler findPinCodeHandler = new FindPinCodeHandler();
AddSummaMoneyHandler addSummaMoneyHandler = new AddSummaMoneyHandler();
AddMoneyHandler addMoneyHandler = new AddMoneyHandler();


while (true){
    Console.WriteLine("Введите команду для дальнейшей работы");
    Console.WriteLine("""
        1. Регистрация
        2. Внести средства
        Наберите любой другой символ, чтобы выйти!
        """);
    string request = Console.ReadLine();
    if(request == "1")
    {
        Request requestUser = new Request() { Data = new BankData()};
        addNameUserHandler.SetNextHandler(addSurnameHandler);
        addSurnameHandler.SetNextHandler(addAgeUserHandler);
        addAgeUserHandler.SetNextHandler(addAccountNumberUserHandler);
        addAccountNumberUserHandler.SetNextHandler(addPincodeUserHandler);
        addPincodeUserHandler.SetNextHandler(addNewUserHandler);
        addNameUserHandler.Process(requestUser);
    }
    else if (request == "2")
    {
        Request requestUser = new Request() { Data = new BankData() };
        addAccountNumberUserHandler.SetNextHandler(findAccountNumberHandler);
        findAccountNumberHandler.SetNextHandler(addPincodeUserHandler);
        addPincodeUserHandler.SetNextHandler(findPinCodeHandler);
        findPinCodeHandler.SetNextHandler(addSummaMoneyHandler);
        addSummaMoneyHandler.SetNextHandler(addMoneyHandler);
        addAccountNumberUserHandler.Process(requestUser);
    }
    else
    {
        break;
    }
    Console.WriteLine();
}