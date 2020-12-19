  # VKAPI:
    
Frame:              completed.......

More commands:      in process......

Rest and peace:     later...........

  # INFO:
Чтобы добавить новые команды: 

Создать новый класс который будет наследоваться от абстрактного класса Command, который будет перезаписывать метод Execute и поле Name. Метод Execute в конце должен выполнять client.SendMessage(message) (не обязательно, но если хочется чтобы бот отправил сообщение юзеру, то следует добавить). Также нужно добавить текст, который будет отправлен пользователю в поле Body класса Message. Делается это вот так: Message.Body="Ваша команда"; 
Следующим шагом следует добавить команду в List, чтобы это сделать нужно перейти в класс Commands и добавить в список метода Get new КонструкторВашегоКласса(); . Все готово! Команда успешно добавлена.

P.S. Добавить префикс (чтобы бот отзывался только если сообщение начинается с ! тоже не сложно. Просто в метод Contains абстрактного класса Command нужно изменить строчку 

    return command.Contains(Name); 
на 

    return command.Contains("!"+Name); 
    
, где "!" это ваш опозновательный знак. 



# Взаимодействие с Callback API:

Вконтакте может уведомлять сервер о любых изменениях вашей группы. Подробнее об этом можно почитать на https://vk.com/dev/callback_api , я опишу как правильно настроить сервер, чтобы он был готов принимать от вконтакте другие запросы, а не только message_new. 

1) Создаем новый case находящийся в Контроллере Callback и добавляем наименование типа события в качестве параметра отбора. Не знаю как правильно это обозвать. Думаю ясно 
        Выглядеть это должно вот так: 
        
        switch (responseObject.Value<string>("type"))
        {
            case "message_new":
                ...
                return Ok("ok");
                //добавленный кейс. Он будет выполняться если пользователь отредактировал сообщение в чате. 
                //О всех типах отправляемых данных можно почитать в документации vk dev.
            case "message_edit":
                ...
                return Ok("ok");
                //
            default:
                return Ok("ok");
        }
        

2) Создаем новый класс по пути VkApi\Models\Response и добавляем туда нужные Json параметры, которые вы хотите использовать для считывания. Для примера можно посмотреть на Ping.cs находящийся по тому же пути. Также после этого нужно добавить созданный класс в Commands.cs. 
3) Теперь о том, как правильно заполнить case контроллера. В кейсе message_new я использую рабочий код, который наверняка подойдет, но сейчас я его распишу понятнее. 

        //Десериализуем запрос от вконтакте в нужный нам класс. 
        //В данном случае используется  выдуманный класс Test, 
        //вам нужно заменить его на класс, который вы создали во 2 пункте. 
        //В итоге получается объект класса Test и заполненные поля из json,
        //который отправил вам Callback API 
        //(Если вы все правильно сделали конечно). 
        
        var test = JsonConvert.DeserializeObject<Test>(strRequest); 
        
        //Тут перебираю каждый элемент списка и вызываю метод Contains, 
        //который содержит сообщение пользователя и проверяет есть ли в сообщении команда.
        
        var command = commands.FirstOrDefault(x => x.Contains(msg.users.Body));

        if (command == null) //проверка на нал
        {
            //Возвращаем ок если команда не найдена. 
            //То есть ничего не делаем. Это обязательно, 
            //иначе вк будет долбить сервер и будет спам от бота одинаковыми сообщениями. 
            
            return Ok("ok");                        
        }
        //Запускаем выполнение команды 
        
        command.Execute(client, new VKMessage { User_Id = msg.users.Id, Body = ""});       
        
        
4) Должно все работать! Если я ничего не забыл конечно. 
        
