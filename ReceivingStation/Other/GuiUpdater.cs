﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using ReceivingStation.Decode;

namespace ReceivingStation.Other
{
    /// <summary>
    /// Класс для работы с пользовательским интерфейсом.
    /// </summary>
    /// <remarks>
    /// Класс отвечает за обновление данных на форме, 
    /// создание элементов формы, плавную прорисовку формы при загрузке и закрытии формы.
    /// </remarks>
    static class GuiUpdater
    {       
        public static Color ErrorColor = Color.FromArgb(222, 211, 47, 47);
        public static Color OkColor = Color.FromArgb(222, 46, 125, 50);

        private delegate void SetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);

        public static void SetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
        {
            var propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;

            if (propertyInfo == null || !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) || @this.GetType().GetProperty(
                propertyInfo.Name, propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>
                (SetPropertyThreadSafe),
                new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(
                    propertyInfo.Name,
                    BindingFlags.SetProperty,
                    null,
                    @this,
                    new object[] { value });
            }
        }

        /// <summary>
        /// Добавление текста в RichTextBox.
        /// </summary>
        /// <remarks>
        /// Отличается от стандартного AppendText тем, что позволяет поменять цвет текста.
        /// </remarks>
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }       

        /// <summary>
        /// Плавная загрузка формы.
        /// </summary>
        /// <param name="form">Форма.</param> 
        public static void SmoothLoadingForm(Form form)
        {
            form.Opacity = 0;
            Timer timer = new Timer();

            timer.Tick += (sender, e) =>
            {
                if ((form.Opacity += 0.05d) == 1)
                {
                    timer.Stop();
                }
            };

            timer.Interval = 10;
            timer.Start();
        }

        /// <summary>
        /// Плавная закрытие формы.
        /// </summary>
        /// <param name="form">Форма.</param> 
        public static void SmoothHidingForm(Form form)
        {
            Timer timer = new Timer();

            timer.Tick += (sender, e) =>
            {
                if ((form.Opacity -= 0.05d) == 0)
                {
                    timer.Stop();
                }
            };

            timer.Interval = 10;
            timer.Start();
        }     

        /// <summary>
        /// Инициализация кастомных RichTextBox с данными декодирования.
        /// </summary>
        /// <remarks>
        /// Отличается от обычного тем, что по умолчанию он недоступен для редактирования (Enabled = false),
        /// но выглядит как доступный. Используется во вкладках меню "Прием" и "Декодирование".
        /// </remarks>
        /// <param name="rtbMko">RichTextBox для заголовков МКО.</param> 
        /// <param name="rtbMkoData">RichTextBox для данных МКО.</param> 
        /// <param name="rtbDateTimeTitle">RichTextBox для заголовков даты и времени из МКО.</param>
        /// <param name="rtbDateTime">RichTextBox для даты и времени из МКО.</param>
        public static void DecodeRichTextBoxInit(DisabledRichTextBox rtbMko, DisabledRichTextBox rtbMkoData, DisabledRichTextBox rtbDateTimeTitle, DisabledRichTextBox rtbDateTime)
        {
            RobotoFont.AllocFont(rtbMko, 11);
            RobotoFont.AllocFont(rtbMkoData, 11);
            RobotoFont.AllocFont(rtbDateTimeTitle, 11);
            RobotoFont.AllocFont(rtbDateTime, 11);

            var MkoTitle = "Время конца формирования ТД (БШВ)\n\n" +
                "Первый год в текущем четырехлетии\n\n" +
                "Номер текущих суток четырехлетия\n\n" +
                "Оцифрованная бортовая шкала времени (БШВ)\n\n" +
                "Время конца формирования ППО (БШВ)\n\n" +
                "Параметры кватерниона L0\n\n" +
                "Параметры кватерниона L1\n\n" +
                "Параметры кватерниона L2\n\n" +
                "Параметры кватерниона L3\n\n" +
                "Время конца формирования ПЦДМ (БШВ)\n\n" +
                "Положение КА по оси X в формате IEEE-754 двойной\n\n" +
                "Положение КА по оси Y в формате IEEE-754 двойной\n\n" +
                "Положение КА по оси Z в формате IEEE-754 двойной";
            rtbMko.Text = MkoTitle;
            rtbMko.BorderStyle = BorderStyle.None;

            var mkoData = "0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0";
            rtbMkoData.Text = mkoData;
            rtbMkoData.BorderStyle = BorderStyle.None;

            var dateTimeTitle = "\nМКО Дата:\n\nМКО Время:";
            rtbDateTimeTitle.Text = dateTimeTitle;
            rtbDateTimeTitle.BorderStyle = BorderStyle.None;

            var dateTime = "\n0.0.0\n\n0:0:0";
            rtbDateTime.Text = dateTime;
            rtbDateTime.BorderStyle = BorderStyle.None;
        }

        #region Обновление данных декодирования на GUI.

        /// <summary>
        /// Обновление данных декодирования на GUI.
        /// </summary>
        /// <param name="linesTd">Значения ТД полученной полосы.</param> 
        /// <param name="linesOshv">Значения ОШВ полученной полосы.</param> 
        /// <param name="linesBshv">Значения БШВ полученной полосы.</param>
        /// <param name="linesPcdm">Значения ПЦДМ полученной полосы.</param>
        /// <param name="linesDate">Значения Даты и времени полученной полосы.</param> 
        /// <param name="rtbDateTime">RichTextBox для даты и времени из МКО.</param> 
        /// <param name="rtbMkoData">RichTextBox для данных МКО.</param>
        /// <param name="channels">Набор FlowLayoutPanel для одиночных каналов.</param> 
        /// <param name="allChannels">Набор FlowLayoutPanel для каналов на вкладке "Все каналы".</param> 
        /// <param name="channelsPanels">Набор контейнеров на которых находятся FlowLayoutPanel для одиночных каналов.</param>
        /// <param name="allChannelsPanels">Набор контейнеров на которых находятся FlowLayoutPanel для каналов на вкладке "Все каналы".</param>
        /// <param name="listImagesForSave">Список хранящий изображения по каждому каналу.</param> 
        /// <param name="imagesLines">Полученные полосы изображений по каждому каналу.</param> 
        public static void UpdateGuiDecodeData(string linesTd, string linesOshv, string linesBshv, string linesPcdm, DateTime linesDate,
            DisabledRichTextBox rtbDateTime, DisabledRichTextBox rtbMkoData, FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, Panel[] channelsPanels, Panel[] allChannelsPanels, List<Bitmap>[] listImagesForSave, DirectBitmap[] imagesLines)
        {
            var td = linesTd.Split(' ');
            var oshv = linesOshv.Split(' ');
            var bshv = linesBshv.Split(' ');
            var pcdm = linesPcdm.Split(' ');

            // Собираем данные в richTextBox. Стремновато, но так быстрее. Если использовать 15 лейблов, то время декодирования увеличится где то на 20%.
            var mkoData = $"{td[0]} {td[1]}\n\n{td[2]}\n\n{td[3]}\n\n{oshv[0]} {oshv[1]}\n\n{bshv[0]} {bshv[1]}\n\n{bshv[2]} {bshv[3]}\n\n{bshv[4]} {bshv[5]}\n\n{bshv[6]} {bshv[7]}\n\n{bshv[8]} {bshv[9]}\n\n{pcdm[0]} {pcdm[1]}\n\n{pcdm[2]} {pcdm[3]} {pcdm[4]} {pcdm[5]}\n\n{pcdm[6]} {pcdm[7]} {pcdm[8]} {pcdm[9]}\n\n{pcdm[10]} {pcdm[11]} {pcdm[12]} {pcdm[13]}";
            var date = $"{linesDate.Day}.{linesDate.Month}.{linesDate.Year}";
            var time = $"{linesDate.Hour:D2}:{linesDate.Minute:D2}:{linesDate.Second:D2}";
            var dateTime = $"\n{date}\n\n{time}";

            rtbDateTime.Text = dateTime;
            rtbMkoData.Text = mkoData;
            CreateNewFlps(channels, allChannels, channelsPanels, allChannelsPanels);
            AddImages(channels, allChannels, listImagesForSave, imagesLines);
        }

        /// <summary>
        /// Получение нового FlowLayoutPanel.
        /// </summary>
        /// <param name="size">Размер FlowLayoutPanel.</param> 
        /// <returns>
        /// FlowLayoutPanel заданного размера.
        /// </returns>
        public static FlowLayoutPanel GetFlp(Size size)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Size = size,
                AutoSize = true,
                Location = new Point(0, 0)
            };

            return flp;
        }

        /// <summary>
        /// Создает наборы FlowLayoutPanel для всех каналов и каждого канала отдельно.
        /// </summary>
        /// <remarks>
        /// Уничтожает текущие FlowLayoutPanel в каждом наборе (списке) и создает на их месте новые.
        /// Так намного быстрее, чем через простую очистку FlowLayoutPanel.
        /// </remarks>
        /// <param name="channels">Набор FlowLayoutPanel для одиночных каналов.</param> 
        /// <param name="allChannels">Набор FlowLayoutPanel для каналов на вкладке "Все каналы".</param> 
        /// <param name="pChannels">Набор контейнеров на которых находятся FlowLayoutPanel для одиночных каналов.</param>
        /// <param name="pAllChannels">Набор контейнеров на которых находятся FlowLayoutPanel для каналов на вкладке "Все каналы".</param>
        private static void CreateNewFlps(FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, Panel[] pChannels, Panel[] pAllChannels)
        {
            if (allChannels[0].Height >= pAllChannels[0].Height)
            {
                for (int i = 0; i < 6; i++)
                {
                    allChannels[i].Dispose();
                    allChannels[i] = GetFlp(new Size(242, 8));
                    pAllChannels[i].Controls.Add(allChannels[i]);

                    channels[i].Dispose();
                    channels[i] = GetFlp(new Size(1556, 40));
                    pChannels[i].Controls.Add(channels[i]);
                }
            }
        }

        /// <summary>
        /// Добавление полученных полос изображений для каждого канала на FlowLayoutPanel и в список хранящий изображения по каждому каналу.
        /// </summary>
        /// <param name="channels">Набор FlowLayoutPanel для одиночных каналов.</param> 
        /// <param name="allChannels">Набор FlowLayoutPanel для каналов на вкладке "Все каналы".</param> 
        /// <param name="listImagesForSave">Список хранящий изображения по каждому каналу.</param>
        /// <param name="imagesLines">Полученные полосы изображений по каждому каналу.</param>
        private static void AddImages(FlowLayoutPanel[] channels, FlowLayoutPanel[] allChannels, List<Bitmap>[] listImagesForSave, DirectBitmap[] imagesLines)
        {
            for (int i = 0; i < imagesLines.Length; i++)
            {
                Bitmap image = new Bitmap(imagesLines[i].Bitmap);

                channels[i].Controls.Add(new DoubleBufferedPanel { Size = new Size(Constants.WDT, Constants.HGT), BackgroundImage = image, Margin = new Padding(0) });

                allChannels[i].Controls.Add(new DoubleBufferedPanel { Size = new Size(allChannels[i].Width, Constants.HGT), BackgroundImage = image, BackgroundImageLayout = ImageLayout.Stretch, Margin = new Padding(0) });

                listImagesForSave[i].Add(image);
            }
        }
        #endregion
    }
}
