# VkPlayer
Простой плеер, который воспроизводит аудиозаписи с вашей страницы ВКонтакте. Плюсом явлется то, что он мало весит и занимает лишь малую часть оперативной памяти, что позволяет не открывая браузер слушать свои аудиозаписи не боясь того, что он будет занимать весомую часть ресурсов вашего ПК.
<hr>
<h3><a href="https://www.microsoft.com/ru-RU/download/details.aspx?id=17851">Для функционирования приложения требуется .NET Framework</a></h3>
<hr>
<h1>Горячие клавиши</h1>
<ul>
  <li><b>Space</b> - пауза/вопроизведение текущей аудиозаписи</li>  
  <li><b>Стрелка вверх</b> - увеличение громкости звука на 5 единиц</li> 
  <li><b>Стрелка вниз</b> - уменьшение громкости звука на 5 единиц</li> 
  <li><b>Стрелка влево</b> -  предыдущий трек</li> 
  <li><b>Стрелка вправо</b> -  следующий трек</li> 
  <li><b>M</b> -  включить/выключить звук</li> 
  <li><b>O</b> -  выбор своего плейлиста</li> 
  <li><b>R</b> -  выбор плейлиста рекомендаций</li> 
  <li><b>H</b> -  выбор плейлиста популярное</li> 
  <li><b>L</b> -  показать\скрыть область просмотра аудиозаписей</li> 
</ul>
<hr>
<h1>Версии</h1>
<h2>1.0</h2>
<ul>
<li>Реализован минимальный интерфейс музыкального проигрывателя, включающий в себя название трека, исполнителя трека, кнопок пауза/воспроизведение, следующий, предыдущий трек, ползунок громкости и длительности</li>
</ul>
<h2>1.1</h2>
<ul>
<li>Теперь можно выбирать цветовые оформления из представленны</li>
<li>Реализована возможность включения повтора, случайного порядках</li>
<li>Добавлены горячие клавиши</li>
<li>Добавлена иконка, отредактирован фаил с атрибутами</li>
</ul>
<h2>1.2</h2>
<ul>
<li>Стала возможна двухфакторная аутентификация</li>
<li>Пофикшены некоторые баги</li>
<li>Немного отрефакторил код</li>
</ul>
<h2>1.3</h2>
<ul>
<li>Изменен значок "повторить" на более понятный</li>
<li>Изменение цвета теперь происзодит по вызову контекстного меню по щелчку правой кнопкой мыши</li>
<li>Добавлены индикаторы времени текущей композиции</li>
<li>Исправил некоторые баги</li>
<li>Убрал ненужные методы и отрефачил код</li>
</ul>
<h2>1.4</h2>
<ul>
<li>Добавлена темная тема</li>
<li>Исправлено поведение на предыдущий/следующий трек</li>
<li>При изменении позиции композиции индикатор текущего времени теперь обновляется сразу</li>
</ul>
<h2>1.5</h2>
<ul>
<li><b>Добавлен поиск аудиозаписей</b></li>
<li>Изменена иконка выхода из учетной записи</li>
<li>Пофиксил баги</li>
</ul>
<h2>1.6</h2>
<ul>
<li>Изменен размер области поиска аудиозаписей</li>
<li>Больше не нужно ставить галочку если на аккаунте двухфакторная аутентификация</li>
<li>Изменен дизайн у окон авторизации</li>
</ul>
<h2>1.7</h2>
<ul>
<li><b>Добавлена возможность просмотра текущего плейлиста</b></li>
<li><b>Переработан метод пролистывания у своих аудиозаписей, зависания намертво больше нет</b></li>
<li><b>Добавлены плейлисты "популярное" и "рекомендации"</b></li>
<li>Изменена чувствительность стрелок вверх\вниз. Теперь ход равен 1</li>
<li>Изменен размер и местоположение окон авторизации</li>
<li>Добавлены горячие клавиши для выбора плейлистов</li>
</ul>
<h2>1.7.1</h2>
<ul>
<li>Рефакторинг кода. Убрал try {try }</li>
<li>Пофиксил некоторые баги</li>
</ul>
<hr>
<h2>FAQ</h2>
<ul>
<li>Для выбора цветового оформления нажмите на правую кнопку мыши</li>
<li>Для переключения плейлиста с поискового на личный нужно стереть текст, написанный в строке для поиска</li>
<li>В поиске всего 20 аудиозаписей: вначале идут аудиозаписи пользователя, затем аудиозаписи из глобального поиска</li>
<li>Для переключения плейлистов нужно нажать значок list в правом верхнем углу, затем нажать на желаемый плейлист.</li>
<li>Для выбора плейлиста поиска ввести в TextBox название и нажать Enter</li>
<li>Для переключения на свой плейлист нажать на значок, расположенный снизу от list</li>
</ul>
<hr>
<h1>Известные баги</h1>
<ul>
<li>Горячие клавиши включаются со второго нажатия</li>
</ul>
<hr>
<h2>Дальнейшее развитие</h2>
<font>Основная цель выполнена. Реализован простейший онлайн-плеер, осуществлена возможность поиска. Несмотря на это в дальнейшем планирую:</font> 
<ul>
<li>Фиксить имеющиеся или появляющиеся баги</li> 
<li>Сделать поиск аудиозаписей без глобального поиска</li>
<li>Переделать весь или часть проекта с WF на WPF</li>
<li>Добавить оффлайн режим</li>
<li>Добавить воспроизведение аудиозаписей групп</li>
</ul>
<hr>
<h2><a href ="https://yadi.sk/d/X2PGbH7l2dyhjQ" target="_blank">Скачать</a> с Яндекс.Диска</h2>
