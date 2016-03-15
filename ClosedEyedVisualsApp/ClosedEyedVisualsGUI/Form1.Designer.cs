namespace ClosedEyedVisualsGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox_ImageSource = new System.Windows.Forms.PictureBox();
            this.timer_Runtime = new System.Windows.Forms.Timer(this.components);
            this.tabPage_OCR = new System.Windows.Forms.TabPage();
            this.textBox_OcrImage = new System.Windows.Forms.TextBox();
            this.textBox_OcrResult = new System.Windows.Forms.TextBox();
            this.label_OcrImage = new System.Windows.Forms.Label();
            this.button_StartOCR = new System.Windows.Forms.Button();
            this.tabPage_Settings = new System.Windows.Forms.TabPage();
            this.button_startPointGreyCam = new System.Windows.Forms.Button();
            this.textBox_VideoMode = new System.Windows.Forms.TextBox();
            this.textBox_CameraInfo = new System.Windows.Forms.TextBox();
            this.label_ImageSourceStatus = new System.Windows.Forms.Label();
            this.button_TakeSnapshot = new System.Windows.Forms.Button();
            this.label_VideoMode = new System.Windows.Forms.Label();
            this.button_RefreshVideoDeviceList = new System.Windows.Forms.Button();
            this.comboBox_VideoDevicesList = new System.Windows.Forms.ComboBox();
            this.button_StartImageSource = new System.Windows.Forms.Button();
            this.tabPage_TemplateDetection = new System.Windows.Forms.TabPage();
            this.textBox_Treshold = new System.Windows.Forms.TextBox();
            this.textBox_SourceImage = new System.Windows.Forms.TextBox();
            this.textBox_TemplateImage = new System.Windows.Forms.TextBox();
            this.textBox_PyramidLevels = new System.Windows.Forms.TextBox();
            this.textBox_PointY = new System.Windows.Forms.TextBox();
            this.textBox_PointX = new System.Windows.Forms.TextBox();
            this.textBox_RoiHeight = new System.Windows.Forms.TextBox();
            this.textBox_RoiWidth = new System.Windows.Forms.TextBox();
            this.label_Treshold = new System.Windows.Forms.Label();
            this.label_SourceImage = new System.Windows.Forms.Label();
            this.label_TemplateImage = new System.Windows.Forms.Label();
            this.button_ExhaustiveMatchingInROI = new System.Windows.Forms.Button();
            this.label_Result = new System.Windows.Forms.Label();
            this.label_ResultOutput = new System.Windows.Forms.Label();
            this.label_ProcessingTime = new System.Windows.Forms.Label();
            this.label_ProcessingTimeOutput = new System.Windows.Forms.Label();
            this.label_PyramidLevels = new System.Windows.Forms.Label();
            this.label_Similarity = new System.Windows.Forms.Label();
            this.button_ExhaustiveMatching = new System.Windows.Forms.Button();
            this.label_SimilarityOutput = new System.Windows.Forms.Label();
            this.label_RoiWidth = new System.Windows.Forms.Label();
            this.label_RoiHeight = new System.Windows.Forms.Label();
            this.label_PointX = new System.Windows.Forms.Label();
            this.label_PointY = new System.Windows.Forms.Label();
            this.tabPage_Main = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImageSource)).BeginInit();
            this.tabPage_OCR.SuspendLayout();
            this.tabPage_Settings.SuspendLayout();
            this.tabPage_TemplateDetection.SuspendLayout();
            this.tabPage_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_ImageSource
            // 
            this.pictureBox_ImageSource.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox_ImageSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_ImageSource.Location = new System.Drawing.Point(354, 10);
            this.pictureBox_ImageSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox_ImageSource.Name = "pictureBox_ImageSource";
            this.pictureBox_ImageSource.Size = new System.Drawing.Size(640, 480);
            this.pictureBox_ImageSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ImageSource.TabIndex = 23;
            this.pictureBox_ImageSource.TabStop = false;
            // 
            // timer_Runtime
            // 
            this.timer_Runtime.Interval = 20;
            this.timer_Runtime.Tick += new System.EventHandler(this.timer_Runtime_Tick);
            // 
            // tabPage_OCR
            // 
            this.tabPage_OCR.Controls.Add(this.textBox_OcrImage);
            this.tabPage_OCR.Controls.Add(this.textBox_OcrResult);
            this.tabPage_OCR.Controls.Add(this.label_OcrImage);
            this.tabPage_OCR.Controls.Add(this.button_StartOCR);
            this.tabPage_OCR.Location = new System.Drawing.Point(4, 22);
            this.tabPage_OCR.Name = "tabPage_OCR";
            this.tabPage_OCR.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_OCR.Size = new System.Drawing.Size(326, 460);
            this.tabPage_OCR.TabIndex = 2;
            this.tabPage_OCR.Text = "OCR";
            this.tabPage_OCR.UseVisualStyleBackColor = true;
            // 
            // textBox_OcrImage
            // 
            this.textBox_OcrImage.Location = new System.Drawing.Point(88, 19);
            this.textBox_OcrImage.Name = "textBox_OcrImage";
            this.textBox_OcrImage.Size = new System.Drawing.Size(100, 20);
            this.textBox_OcrImage.TabIndex = 3;
            // 
            // textBox_OcrResult
            // 
            this.textBox_OcrResult.Location = new System.Drawing.Point(3, 348);
            this.textBox_OcrResult.Multiline = true;
            this.textBox_OcrResult.Name = "textBox_OcrResult";
            this.textBox_OcrResult.Size = new System.Drawing.Size(317, 106);
            this.textBox_OcrResult.TabIndex = 1;
            // 
            // label_OcrImage
            // 
            this.label_OcrImage.AutoSize = true;
            this.label_OcrImage.Location = new System.Drawing.Point(25, 19);
            this.label_OcrImage.Name = "label_OcrImage";
            this.label_OcrImage.Size = new System.Drawing.Size(56, 13);
            this.label_OcrImage.TabIndex = 2;
            this.label_OcrImage.Text = "OcrImage:";
            // 
            // button_StartOCR
            // 
            this.button_StartOCR.Location = new System.Drawing.Point(25, 58);
            this.button_StartOCR.Name = "button_StartOCR";
            this.button_StartOCR.Size = new System.Drawing.Size(75, 23);
            this.button_StartOCR.TabIndex = 0;
            this.button_StartOCR.Text = "StartOCR";
            this.button_StartOCR.UseVisualStyleBackColor = true;
            this.button_StartOCR.Click += new System.EventHandler(this.button_StartOCR_Click);
            // 
            // tabPage_Settings
            // 
            this.tabPage_Settings.Controls.Add(this.button_startPointGreyCam);
            this.tabPage_Settings.Controls.Add(this.textBox_VideoMode);
            this.tabPage_Settings.Controls.Add(this.textBox_CameraInfo);
            this.tabPage_Settings.Controls.Add(this.label_ImageSourceStatus);
            this.tabPage_Settings.Controls.Add(this.button_TakeSnapshot);
            this.tabPage_Settings.Controls.Add(this.label_VideoMode);
            this.tabPage_Settings.Controls.Add(this.button_RefreshVideoDeviceList);
            this.tabPage_Settings.Controls.Add(this.comboBox_VideoDevicesList);
            this.tabPage_Settings.Controls.Add(this.button_StartImageSource);
            this.tabPage_Settings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Settings.Name = "tabPage_Settings";
            this.tabPage_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Settings.Size = new System.Drawing.Size(326, 460);
            this.tabPage_Settings.TabIndex = 1;
            this.tabPage_Settings.Text = "Setings";
            this.tabPage_Settings.UseVisualStyleBackColor = true;
            // 
            // button_startPointGreyCam
            // 
            this.button_startPointGreyCam.Location = new System.Drawing.Point(132, 12);
            this.button_startPointGreyCam.Margin = new System.Windows.Forms.Padding(2);
            this.button_startPointGreyCam.Name = "button_startPointGreyCam";
            this.button_startPointGreyCam.Size = new System.Drawing.Size(107, 19);
            this.button_startPointGreyCam.TabIndex = 31;
            this.button_startPointGreyCam.Text = "StartPointGreyCam";
            this.button_startPointGreyCam.UseVisualStyleBackColor = true;
            this.button_startPointGreyCam.Click += new System.EventHandler(this.button_startPointGreyCam_Click);
            // 
            // textBox_VideoMode
            // 
            this.textBox_VideoMode.Location = new System.Drawing.Point(74, 12);
            this.textBox_VideoMode.Name = "textBox_VideoMode";
            this.textBox_VideoMode.Size = new System.Drawing.Size(28, 20);
            this.textBox_VideoMode.TabIndex = 1;
            this.textBox_VideoMode.Text = "0";
            // 
            // textBox_CameraInfo
            // 
            this.textBox_CameraInfo.Location = new System.Drawing.Point(5, 169);
            this.textBox_CameraInfo.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CameraInfo.Multiline = true;
            this.textBox_CameraInfo.Name = "textBox_CameraInfo";
            this.textBox_CameraInfo.Size = new System.Drawing.Size(316, 286);
            this.textBox_CameraInfo.TabIndex = 29;
            // 
            // label_ImageSourceStatus
            // 
            this.label_ImageSourceStatus.AutoSize = true;
            this.label_ImageSourceStatus.Location = new System.Drawing.Point(6, 116);
            this.label_ImageSourceStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ImageSourceStatus.Name = "label_ImageSourceStatus";
            this.label_ImageSourceStatus.Size = new System.Drawing.Size(147, 13);
            this.label_ImageSourceStatus.TabIndex = 26;
            this.label_ImageSourceStatus.Text = "CameraStatus:Not connected";
            // 
            // button_TakeSnapshot
            // 
            this.button_TakeSnapshot.Location = new System.Drawing.Point(122, 78);
            this.button_TakeSnapshot.Margin = new System.Windows.Forms.Padding(2);
            this.button_TakeSnapshot.Name = "button_TakeSnapshot";
            this.button_TakeSnapshot.Size = new System.Drawing.Size(97, 26);
            this.button_TakeSnapshot.TabIndex = 30;
            this.button_TakeSnapshot.Text = "TakeSnapshot";
            this.button_TakeSnapshot.UseVisualStyleBackColor = true;
            this.button_TakeSnapshot.Click += new System.EventHandler(this.button_TakeSnapshot_Click);
            // 
            // label_VideoMode
            // 
            this.label_VideoMode.AutoSize = true;
            this.label_VideoMode.Location = new System.Drawing.Point(6, 12);
            this.label_VideoMode.Name = "label_VideoMode";
            this.label_VideoMode.Size = new System.Drawing.Size(61, 13);
            this.label_VideoMode.TabIndex = 0;
            this.label_VideoMode.Text = "VideoMode";
            // 
            // button_RefreshVideoDeviceList
            // 
            this.button_RefreshVideoDeviceList.Location = new System.Drawing.Point(9, 51);
            this.button_RefreshVideoDeviceList.Margin = new System.Windows.Forms.Padding(2);
            this.button_RefreshVideoDeviceList.Name = "button_RefreshVideoDeviceList";
            this.button_RefreshVideoDeviceList.Size = new System.Drawing.Size(109, 22);
            this.button_RefreshVideoDeviceList.TabIndex = 28;
            this.button_RefreshVideoDeviceList.Text = "UpdateDeviceList";
            this.button_RefreshVideoDeviceList.UseVisualStyleBackColor = true;
            this.button_RefreshVideoDeviceList.Click += new System.EventHandler(this.button_RefreshVideoDeviceList_Click);
            // 
            // comboBox_VideoDevicesList
            // 
            this.comboBox_VideoDevicesList.FormattingEnabled = true;
            this.comboBox_VideoDevicesList.Location = new System.Drawing.Point(122, 53);
            this.comboBox_VideoDevicesList.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_VideoDevicesList.Name = "comboBox_VideoDevicesList";
            this.comboBox_VideoDevicesList.Size = new System.Drawing.Size(119, 21);
            this.comboBox_VideoDevicesList.TabIndex = 27;
            // 
            // button_StartImageSource
            // 
            this.button_StartImageSource.Location = new System.Drawing.Point(9, 78);
            this.button_StartImageSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_StartImageSource.Name = "button_StartImageSource";
            this.button_StartImageSource.Size = new System.Drawing.Size(97, 19);
            this.button_StartImageSource.TabIndex = 24;
            this.button_StartImageSource.Text = "Start";
            this.button_StartImageSource.UseVisualStyleBackColor = true;
            this.button_StartImageSource.Click += new System.EventHandler(this.button_StartImageSource_Click);
            // 
            // tabPage_TemplateDetection
            // 
            this.tabPage_TemplateDetection.Controls.Add(this.textBox_Treshold);
            this.tabPage_TemplateDetection.Controls.Add(this.textBox_SourceImage);
            this.tabPage_TemplateDetection.Controls.Add(this.textBox_TemplateImage);
            this.tabPage_TemplateDetection.Controls.Add(this.textBox_PyramidLevels);
            this.tabPage_TemplateDetection.Controls.Add(this.textBox_PointY);
            this.tabPage_TemplateDetection.Controls.Add(this.textBox_PointX);
            this.tabPage_TemplateDetection.Controls.Add(this.textBox_RoiHeight);
            this.tabPage_TemplateDetection.Controls.Add(this.textBox_RoiWidth);
            this.tabPage_TemplateDetection.Controls.Add(this.label_Treshold);
            this.tabPage_TemplateDetection.Controls.Add(this.label_SourceImage);
            this.tabPage_TemplateDetection.Controls.Add(this.label_TemplateImage);
            this.tabPage_TemplateDetection.Controls.Add(this.button_ExhaustiveMatchingInROI);
            this.tabPage_TemplateDetection.Controls.Add(this.label_Result);
            this.tabPage_TemplateDetection.Controls.Add(this.label_ResultOutput);
            this.tabPage_TemplateDetection.Controls.Add(this.label_ProcessingTime);
            this.tabPage_TemplateDetection.Controls.Add(this.label_ProcessingTimeOutput);
            this.tabPage_TemplateDetection.Controls.Add(this.label_PyramidLevels);
            this.tabPage_TemplateDetection.Controls.Add(this.label_Similarity);
            this.tabPage_TemplateDetection.Controls.Add(this.button_ExhaustiveMatching);
            this.tabPage_TemplateDetection.Controls.Add(this.label_SimilarityOutput);
            this.tabPage_TemplateDetection.Controls.Add(this.label_RoiWidth);
            this.tabPage_TemplateDetection.Controls.Add(this.label_RoiHeight);
            this.tabPage_TemplateDetection.Controls.Add(this.label_PointX);
            this.tabPage_TemplateDetection.Controls.Add(this.label_PointY);
            this.tabPage_TemplateDetection.Location = new System.Drawing.Point(4, 22);
            this.tabPage_TemplateDetection.Name = "tabPage_TemplateDetection";
            this.tabPage_TemplateDetection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_TemplateDetection.Size = new System.Drawing.Size(326, 460);
            this.tabPage_TemplateDetection.TabIndex = 0;
            this.tabPage_TemplateDetection.Text = "TemplateDetection";
            this.tabPage_TemplateDetection.UseVisualStyleBackColor = true;
            // 
            // textBox_Treshold
            // 
            this.textBox_Treshold.Location = new System.Drawing.Point(235, 97);
            this.textBox_Treshold.Name = "textBox_Treshold";
            this.textBox_Treshold.Size = new System.Drawing.Size(36, 20);
            this.textBox_Treshold.TabIndex = 24;
            // 
            // textBox_SourceImage
            // 
            this.textBox_SourceImage.Location = new System.Drawing.Point(97, 11);
            this.textBox_SourceImage.Name = "textBox_SourceImage";
            this.textBox_SourceImage.Size = new System.Drawing.Size(170, 20);
            this.textBox_SourceImage.TabIndex = 1;
            // 
            // textBox_TemplateImage
            // 
            this.textBox_TemplateImage.Location = new System.Drawing.Point(97, 44);
            this.textBox_TemplateImage.Name = "textBox_TemplateImage";
            this.textBox_TemplateImage.Size = new System.Drawing.Size(170, 20);
            this.textBox_TemplateImage.TabIndex = 3;
            // 
            // textBox_PyramidLevels
            // 
            this.textBox_PyramidLevels.Location = new System.Drawing.Point(235, 71);
            this.textBox_PyramidLevels.Name = "textBox_PyramidLevels";
            this.textBox_PyramidLevels.Size = new System.Drawing.Size(36, 20);
            this.textBox_PyramidLevels.TabIndex = 22;
            // 
            // textBox_PointY
            // 
            this.textBox_PointY.Location = new System.Drawing.Point(97, 151);
            this.textBox_PointY.Name = "textBox_PointY";
            this.textBox_PointY.Size = new System.Drawing.Size(51, 20);
            this.textBox_PointY.TabIndex = 19;
            // 
            // textBox_PointX
            // 
            this.textBox_PointX.Location = new System.Drawing.Point(97, 123);
            this.textBox_PointX.Name = "textBox_PointX";
            this.textBox_PointX.Size = new System.Drawing.Size(51, 20);
            this.textBox_PointX.TabIndex = 18;
            // 
            // textBox_RoiHeight
            // 
            this.textBox_RoiHeight.Location = new System.Drawing.Point(97, 97);
            this.textBox_RoiHeight.Name = "textBox_RoiHeight";
            this.textBox_RoiHeight.Size = new System.Drawing.Size(51, 20);
            this.textBox_RoiHeight.TabIndex = 17;
            // 
            // textBox_RoiWidth
            // 
            this.textBox_RoiWidth.Location = new System.Drawing.Point(97, 71);
            this.textBox_RoiWidth.Name = "textBox_RoiWidth";
            this.textBox_RoiWidth.Size = new System.Drawing.Size(51, 20);
            this.textBox_RoiWidth.TabIndex = 16;
            // 
            // label_Treshold
            // 
            this.label_Treshold.AutoSize = true;
            this.label_Treshold.Location = new System.Drawing.Point(154, 100);
            this.label_Treshold.Name = "label_Treshold";
            this.label_Treshold.Size = new System.Drawing.Size(48, 13);
            this.label_Treshold.TabIndex = 23;
            this.label_Treshold.Text = "Treshold";
            // 
            // label_SourceImage
            // 
            this.label_SourceImage.AutoSize = true;
            this.label_SourceImage.Location = new System.Drawing.Point(14, 13);
            this.label_SourceImage.Name = "label_SourceImage";
            this.label_SourceImage.Size = new System.Drawing.Size(70, 13);
            this.label_SourceImage.TabIndex = 0;
            this.label_SourceImage.Text = "SourceImage";
            // 
            // label_TemplateImage
            // 
            this.label_TemplateImage.AutoSize = true;
            this.label_TemplateImage.Location = new System.Drawing.Point(14, 51);
            this.label_TemplateImage.Name = "label_TemplateImage";
            this.label_TemplateImage.Size = new System.Drawing.Size(80, 13);
            this.label_TemplateImage.TabIndex = 2;
            this.label_TemplateImage.Text = "TemplateImage";
            // 
            // button_ExhaustiveMatchingInROI
            // 
            this.button_ExhaustiveMatchingInROI.Location = new System.Drawing.Point(7, 186);
            this.button_ExhaustiveMatchingInROI.Name = "button_ExhaustiveMatchingInROI";
            this.button_ExhaustiveMatchingInROI.Size = new System.Drawing.Size(141, 23);
            this.button_ExhaustiveMatchingInROI.TabIndex = 4;
            this.button_ExhaustiveMatchingInROI.Text = "ExhaustiveMatchingInROI";
            this.button_ExhaustiveMatchingInROI.UseVisualStyleBackColor = true;
            this.button_ExhaustiveMatchingInROI.Click += new System.EventHandler(this.button_ExhaustiveMatchingInROI_Click);
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Location = new System.Drawing.Point(16, 251);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(43, 13);
            this.label_Result.TabIndex = 5;
            this.label_Result.Text = "Result: ";
            // 
            // label_ResultOutput
            // 
            this.label_ResultOutput.AutoSize = true;
            this.label_ResultOutput.Location = new System.Drawing.Point(16, 273);
            this.label_ResultOutput.Name = "label_ResultOutput";
            this.label_ResultOutput.Size = new System.Drawing.Size(44, 13);
            this.label_ResultOutput.TabIndex = 6;
            this.label_ResultOutput.Text = "Nothing";
            // 
            // label_ProcessingTime
            // 
            this.label_ProcessingTime.AutoSize = true;
            this.label_ProcessingTime.Location = new System.Drawing.Point(16, 310);
            this.label_ProcessingTime.Name = "label_ProcessingTime";
            this.label_ProcessingTime.Size = new System.Drawing.Size(85, 13);
            this.label_ProcessingTime.TabIndex = 7;
            this.label_ProcessingTime.Text = "ProcessingTime:";
            // 
            // label_ProcessingTimeOutput
            // 
            this.label_ProcessingTimeOutput.AutoSize = true;
            this.label_ProcessingTimeOutput.Location = new System.Drawing.Point(107, 310);
            this.label_ProcessingTimeOutput.Name = "label_ProcessingTimeOutput";
            this.label_ProcessingTimeOutput.Size = new System.Drawing.Size(0, 13);
            this.label_ProcessingTimeOutput.TabIndex = 8;
            // 
            // label_PyramidLevels
            // 
            this.label_PyramidLevels.AutoSize = true;
            this.label_PyramidLevels.Location = new System.Drawing.Point(154, 74);
            this.label_PyramidLevels.Name = "label_PyramidLevels";
            this.label_PyramidLevels.Size = new System.Drawing.Size(75, 13);
            this.label_PyramidLevels.TabIndex = 21;
            this.label_PyramidLevels.Text = "PyramidLevels";
            // 
            // label_Similarity
            // 
            this.label_Similarity.AutoSize = true;
            this.label_Similarity.Location = new System.Drawing.Point(19, 336);
            this.label_Similarity.Name = "label_Similarity";
            this.label_Similarity.Size = new System.Drawing.Size(50, 13);
            this.label_Similarity.TabIndex = 9;
            this.label_Similarity.Text = "Similarity:";
            // 
            // button_ExhaustiveMatching
            // 
            this.button_ExhaustiveMatching.Location = new System.Drawing.Point(8, 216);
            this.button_ExhaustiveMatching.Name = "button_ExhaustiveMatching";
            this.button_ExhaustiveMatching.Size = new System.Drawing.Size(140, 23);
            this.button_ExhaustiveMatching.TabIndex = 20;
            this.button_ExhaustiveMatching.Text = "ExhaustiveMatching";
            this.button_ExhaustiveMatching.UseVisualStyleBackColor = true;
            this.button_ExhaustiveMatching.Click += new System.EventHandler(this.button_ExhaustiveMatching_Click);
            // 
            // label_SimilarityOutput
            // 
            this.label_SimilarityOutput.AutoSize = true;
            this.label_SimilarityOutput.Location = new System.Drawing.Point(76, 336);
            this.label_SimilarityOutput.Name = "label_SimilarityOutput";
            this.label_SimilarityOutput.Size = new System.Drawing.Size(0, 13);
            this.label_SimilarityOutput.TabIndex = 10;
            // 
            // label_RoiWidth
            // 
            this.label_RoiWidth.AutoSize = true;
            this.label_RoiWidth.Location = new System.Drawing.Point(16, 78);
            this.label_RoiWidth.Name = "label_RoiWidth";
            this.label_RoiWidth.Size = new System.Drawing.Size(51, 13);
            this.label_RoiWidth.TabIndex = 12;
            this.label_RoiWidth.Text = "RoiWidth";
            // 
            // label_RoiHeight
            // 
            this.label_RoiHeight.AutoSize = true;
            this.label_RoiHeight.Location = new System.Drawing.Point(14, 102);
            this.label_RoiHeight.Name = "label_RoiHeight";
            this.label_RoiHeight.Size = new System.Drawing.Size(54, 13);
            this.label_RoiHeight.TabIndex = 13;
            this.label_RoiHeight.Text = "RoiHeight";
            // 
            // label_PointX
            // 
            this.label_PointX.AutoSize = true;
            this.label_PointX.Location = new System.Drawing.Point(14, 129);
            this.label_PointX.Name = "label_PointX";
            this.label_PointX.Size = new System.Drawing.Size(38, 13);
            this.label_PointX.TabIndex = 14;
            this.label_PointX.Text = "PointX";
            // 
            // label_PointY
            // 
            this.label_PointY.AutoSize = true;
            this.label_PointY.Location = new System.Drawing.Point(14, 151);
            this.label_PointY.Name = "label_PointY";
            this.label_PointY.Size = new System.Drawing.Size(38, 13);
            this.label_PointY.TabIndex = 15;
            this.label_PointY.Text = "PointY";
            // 
            // tabPage_Main
            // 
            this.tabPage_Main.Controls.Add(this.tabPage_TemplateDetection);
            this.tabPage_Main.Controls.Add(this.tabPage_Settings);
            this.tabPage_Main.Controls.Add(this.tabPage_OCR);
            this.tabPage_Main.Location = new System.Drawing.Point(3, 10);
            this.tabPage_Main.Name = "tabPage_Main";
            this.tabPage_Main.SelectedIndex = 0;
            this.tabPage_Main.Size = new System.Drawing.Size(334, 486);
            this.tabPage_Main.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 508);
            this.Controls.Add(this.tabPage_Main);
            this.Controls.Add(this.pictureBox_ImageSource);
            this.Name = "Form1";
            this.Text = "ClosedEyedVisuals";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImageSource)).EndInit();
            this.tabPage_OCR.ResumeLayout(false);
            this.tabPage_OCR.PerformLayout();
            this.tabPage_Settings.ResumeLayout(false);
            this.tabPage_Settings.PerformLayout();
            this.tabPage_TemplateDetection.ResumeLayout(false);
            this.tabPage_TemplateDetection.PerformLayout();
            this.tabPage_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_ImageSource;
        private System.Windows.Forms.Timer timer_Runtime;
        private System.Windows.Forms.TabPage tabPage_OCR;
        private System.Windows.Forms.TextBox textBox_OcrImage;
        private System.Windows.Forms.TextBox textBox_OcrResult;
        private System.Windows.Forms.Label label_OcrImage;
        private System.Windows.Forms.Button button_StartOCR;
        private System.Windows.Forms.TabPage tabPage_Settings;
        private System.Windows.Forms.Button button_startPointGreyCam;
        private System.Windows.Forms.TextBox textBox_VideoMode;
        private System.Windows.Forms.TextBox textBox_CameraInfo;
        private System.Windows.Forms.Label label_ImageSourceStatus;
        private System.Windows.Forms.Button button_TakeSnapshot;
        private System.Windows.Forms.Label label_VideoMode;
        private System.Windows.Forms.Button button_RefreshVideoDeviceList;
        private System.Windows.Forms.ComboBox comboBox_VideoDevicesList;
        private System.Windows.Forms.Button button_StartImageSource;
        private System.Windows.Forms.TabPage tabPage_TemplateDetection;
        private System.Windows.Forms.TextBox textBox_Treshold;
        private System.Windows.Forms.TextBox textBox_SourceImage;
        private System.Windows.Forms.TextBox textBox_TemplateImage;
        private System.Windows.Forms.TextBox textBox_PyramidLevels;
        private System.Windows.Forms.TextBox textBox_PointY;
        private System.Windows.Forms.TextBox textBox_PointX;
        private System.Windows.Forms.TextBox textBox_RoiHeight;
        private System.Windows.Forms.TextBox textBox_RoiWidth;
        private System.Windows.Forms.Label label_Treshold;
        private System.Windows.Forms.Label label_SourceImage;
        private System.Windows.Forms.Label label_TemplateImage;
        private System.Windows.Forms.Button button_ExhaustiveMatchingInROI;
        private System.Windows.Forms.Label label_Result;
        private System.Windows.Forms.Label label_ResultOutput;
        private System.Windows.Forms.Label label_ProcessingTime;
        private System.Windows.Forms.Label label_ProcessingTimeOutput;
        private System.Windows.Forms.Label label_PyramidLevels;
        private System.Windows.Forms.Label label_Similarity;
        private System.Windows.Forms.Button button_ExhaustiveMatching;
        private System.Windows.Forms.Label label_SimilarityOutput;
        private System.Windows.Forms.Label label_RoiWidth;
        private System.Windows.Forms.Label label_RoiHeight;
        private System.Windows.Forms.Label label_PointX;
        private System.Windows.Forms.Label label_PointY;
        private System.Windows.Forms.TabControl tabPage_Main;
    }

}

