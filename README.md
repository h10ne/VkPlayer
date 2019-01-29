# VkPlayer
Простой плеер, который воспроизводит аудиозаписи с вашей страницы ВКонтакте. Плюсом явлется то, что он мало весит и занимает лишь малую часть оперативной памяти, что позволяет не открывая слушать свои аудиозаписи не боясь того, что браузер будет занимать весомую часть ресурсов вашего ПК.
<hr>
<h1>Горячие клавиши</h1>
<ul>
  <li><b>Space</b> - пауза/вопроизведение текущей аудиозаписи</li>  
  <li><b>Стрелка вверх</b> - увеличение громкости звука на 5 единиц</li> 
  <li><b>Стрелка вниз</b> - уменьшение громкости звука на 5 единиц</li> 
  <li><b>Стрелка влево</b> -  предыдущий трек</li> 
  <li><b>Стрелка вправо</b> -  следующий трек</li> 
  <li><b>M</b> -  включить/выключить звук</li> 
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
<hr>
<h1>Известные баги</h1>
<ul>
<li>Горячие клавиши включаются со второго нажатия</li>
<li>Если быстро листать треки, приложение намертво зависает</li>
<li><del>Иногда при включенном рандоме трек повторяется. Причина: сунул часть кода в try catch, потому что иногда приложение крашилось</del></li>
<li><del>При смене цветов основной фон у кнопок repeat и random не изменяется</del></li>
<li><del>При пролистывании треков стрелками изменяется ползунок громоксти</del></li>
<li><del>При перезапуске приложения цветовое оформление сбрасывается</del></li>
</ul>
<hr>
<h1>Ссылка на Я.диск - <a href ="https://yadi.sk/d/-hq4lIY_N8R4bA" target="_blank">https://yadi.sk/d/-hq4lIY_N8R4bA</a></h1>
