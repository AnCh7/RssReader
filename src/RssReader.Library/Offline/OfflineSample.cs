namespace RssReader.Library.Offline
{
    public static class OfflineSample
    {
        public const string CitydogRssData = @"<?xml version=""1.0""?>
                                                <rss version=""2.0"" xmlns:atom=""http://www.w3.org/2005/Atom"">
                                                    <channel>
                                                        <title>Новости - citydog.by</title>
                                                        <description>Последние обновления - citydog.by</description>
                                                        <link>http://citydog.by/</link>
                                                        <pubDate>Sun, 01 Mar 2015 11:30:10 Europe/Minsk</pubDate>
                                                        <image>
                                                            <title>Последние обновления - citydog.by</title>
                                                            <link>http://citydog.by/</link>
                                                            <url>http://citydog.by/images/citydog_logo.png</url>
                                                            <width>120</width>
                                                            <height>120</height>
                                                        </image>
                                                        <item>
                                                            <title>Вдруг пропустили: 10 интересных материалов CityDog.by за февраль</title>
                                                            <link>http://citydog.by/post/top10-february/</link>
                                                            <description>Геронтолог, Tinder, адвокаты и шенген, а также самый честный фильм о Минске.</description>
                                                            <guid>http://citydog.by/post/top10-february/</guid>
                                                            <pubDate>Sat, 28 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/theme/"">Тема</category>
                                                        </item>
                                                        <item>
                                                            <title>Завтра открытие: экскурсия по выставке «Изобретения да Винчи»</title>
                                                            <link>http://citydog.by/post/da-vinci/</link>
                                                            <description>«Но эта идея оказалась утопичной».</description>
                                                            <guid>http://citydog.by/post/da-vinci/</guid>
                                                            <pubDate>Sat, 28 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/events/"">События</category>
                                                            <category domain=""http://citydog.by/allposts/category/guide/"">Гиды</category>
                                                        </item>
                                                        <item>
                                                            <title>Сериал «Агент Картер»: подруга Капитана Америки сражается с «Левиафаном» в Минской области</title>
                                                            <link>http://citydog.by/post/agent-carter-bssr/</link>
                                                            <description>Прорыв белорусского фронта.</description>
                                                            <guid>http://citydog.by/post/agent-carter-bssr/</guid>
                                                            <pubDate>Sat, 28 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/theme/"">Тема</category>
                                                        </item>
                                                        <item>
                                                            <title>Как мы ходили на stand-up по-белорусски – все грустно</title>
                                                            <link>http://citydog.by/post/standup/</link>
                                                            <description>«Калі я размаўляю па-беларуску, адчуваю сябе чорным у ЗША ў пяцідзесятых».</description>
                                                            <guid>http://citydog.by/post/standup/</guid>
                                                            <pubDate>Fri, 27 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/events/"">События</category>
                                                        </item>
                                                        <item>
                                                            <title>Как закупаться разумно и экономно – сходили в магазин с минской пенсионеркой</title>
                                                            <link>http://citydog.by/post/pension/</link>
                                                            <description>«Думаю, если мужу их сварить, он будет в шоке».</description>
                                                            <guid>http://citydog.by/post/pension/</guid>
                                                            <pubDate>Fri, 27 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/people/"">Люди</category>
                                                            <category domain=""http://citydog.by/allposts/category/theme/"">Тема</category>
                                                        </item>
                                                        <item>
                                                            <title>За день: Квадратный метр за 67 млн – дороже всего в Минске строиться на улице Пионерской, что в Дроздах</title>
                                                            <link>http://citydog.by/post/zaden_2702/</link>
                                                            <description>Готовы вкладывать в такую жилплощадь топ-менеджеры и россияне.</description>
                                                            <guid>http://citydog.by/post/zaden_2702/</guid>
                                                            <pubDate>Fri, 27 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/events/"">События</category>
                                                        </item>
                                                        <item>
                                                            <title>Куда идти в выходные 28 февраля – 1 марта</title>
                                                            <link>http://citydog.by/post/kuda-idti-28feb-1mar/</link>
                                                            <description>Весенняя фотосессия с живыми цветами и проводы зимы.</description>
                                                            <guid>http://citydog.by/post/kuda-idti-28feb-1mar/</guid>
                                                            <pubDate>Fri, 27 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/events/"">События</category>
                                                        </item>
                                                        <item>
                                                            <title>Квартиросъемка: приличная «классика» на площади Победы</title>
                                                            <link>http://citydog.by/post/kvrtsmka-klasika/</link>
                                                            <description>«В молодости не было такого достатка, как сейчас, но всегда было желание иметь лучшее. А для того, чтобы чего-то достичь, приходилось делать больше».</description>
                                                            <guid>http://citydog.by/post/kvrtsmka-klasika/</guid>
                                                            <pubDate>Thu, 26 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/people/"">Люди</category>
                                                            <category domain=""http://citydog.by/allposts/category/places/"">Места</category>
                                                        </item>
                                                        <item>
                                                            <title>В субботу на Октябрьской площади открывается клуб «Куклы»</title>
                                                            <link>http://citydog.by/post/kukly/</link>
                                                            <description>На месте клуба Night People, который был на месте старинного клуба Alcatraz.</description>
                                                            <guid>http://citydog.by/post/kukly/</guid>
                                                            <pubDate>Thu, 26 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/places/"">Места</category>
                                                            <category domain=""http://citydog.by/allposts/category/events/"">События</category>
                                                        </item>
                                                        <item>
                                                            <title>За день: Третью линию метро запустят в 2019 году – будут автоматические поезда, щиты от самоубийц и плитка «Керамин»</title>
                                                            <link>http://citydog.by/post/zaden_2602/</link>
                                                            <description>Об этом на пресс-конференции заявили метростроевцы.</description>
                                                            <guid>http://citydog.by/post/zaden_2602/</guid>
                                                            <pubDate>Thu, 26 Feb 2015</pubDate>
                                                            <category domain=""http://citydog.by/allposts/category/events/"">События</category>
                                                        </item>
                                                    </channel>
                                                </rss>";
    }
}