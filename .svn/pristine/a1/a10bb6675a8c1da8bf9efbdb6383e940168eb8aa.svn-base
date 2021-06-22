using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}

		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";

			viewPort.Invalidate();
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked)
			{
				Shape selec = dialogProcessor.ContainsPoint(e.Location);
				if (selec != null)
				{
					if (dialogProcessor.Selection.Contains(selec))
					{
						selec.FillColor = dialogProcessor.currentFillColor;
						dialogProcessor.Selection.Remove(selec);

					}
					else
					{
						dialogProcessor.Selection.Add(selec);
					}
				}

				statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
				dialogProcessor.IsDragging = true;
				dialogProcessor.LastLocation = e.Location;
				viewPort.Invalidate();

			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging)
			{
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

		private void speedMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void drawEllipseSpeedButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomEllipse();

			statusBar.Items[0].Text = "Последно действие: Рисуване на елипса.";

			viewPort.Invalidate();
		}

		private void DrawPointSpeedButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomPoint();

			statusBar.Items[0].Text = "Последно действие: Рисуване на точка.";

			viewPort.Invalidate();
		}

		private void drawLineSpeedButton_Click(object sender, EventArgs e)
		{

			dialogProcessor.AddRandomLine();

			statusBar.Items[0].Text = "Последно действие: Рисуване на отсечка.";

			viewPort.Invalidate();
		}

		private void drawPolygonSpeedButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomPolygon();

			statusBar.Items[0].Text = "Последно действие: Рисуване на петоъгълник.";

			viewPort.Invalidate();
		}

		private void drawCircleSpeedButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomCircle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на кръг.";

			viewPort.Invalidate();
		}

		private void colorSelectPickBtn_Click(object sender, EventArgs e)
		{
			if (colorSelectDialog.ShowDialog() == DialogResult.OK)
			{

				foreach (Shape item in dialogProcessor.Selection)
				{
					item.StrokeColor = colorSelectDialog.Color;
					viewPort.Invalidate();
				}
				dialogProcessor.currentStrokeColor = colorSelectDialog.Color;
				dialogProcessor.ChangeGroupStrokeColor(colorSelectDialog.Color);
				statusBar.Items[0].Text = "Последно действие: Смяна на цвета на контура.";

			}
		}

		private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				dialogProcessor.SerializeFile(dialogProcessor.ShapeList, saveFileDialog1.FileName);
			}
			statusBar.Items[0].Text = "Последно действие: Записване на файл.";
		}

		private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				dialogProcessor.ShapeList = (List<Shape>)dialogProcessor.DeSerializeFile(openFileDialog1.FileName);
				viewPort.Invalidate();
			}
			statusBar.Items[0].Text = "Последно действие: Отваряне на файл.";
		}

		//toolStripButton1_Click
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			if (fillColorSelectDialog.ShowDialog() == DialogResult.OK)
			{

				foreach (Shape item in dialogProcessor.Selection)
				{
					item.FillColor = fillColorSelectDialog.Color;
					viewPort.Invalidate();
				}
				dialogProcessor.currentFillColor = fillColorSelectDialog.Color;
				dialogProcessor.ChangeGroupFillColor(fillColorSelectDialog.Color);
				statusBar.Items[0].Text = "Последно действие: Смяна на цвета на запълване.";

			}
		}


		private void OpacityPicker_Click(object sender, EventArgs e)
		{

		}

		private void OpacityPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			string opacityValue = OpacityPicker.Text;
			if (opacityValue != null)
			{
				if (opacityValue == "Transparent")
                {
					dialogProcessor.currentOpac = 0;
					dialogProcessor.ChangeGroupOpacity(0);

				}
				
				else if (opacityValue == "Not transparent")
                {
					dialogProcessor.currentOpac = 1;
					dialogProcessor.ChangeGroupOpacity(1);

				}


				statusBar.Items[0].Text = "Последно действие: Задаване на прозрачност.";
				viewPort.Invalidate();
			}
		}

		private void selectedShapesColor_Click(object sender, EventArgs e)
		{
			if (selectedShapesColorDialog.ShowDialog() == DialogResult.OK)
			{

				foreach (Shape item in dialogProcessor.Selection)
				{
					item.FillColor = selectedShapesColorDialog.Color;
					viewPort.Invalidate();
				}
				dialogProcessor.currentSelectedColor = selectedShapesColorDialog.Color;
				
				statusBar.Items[0].Text = "Последно действие: Смяна на цвета на запълване при селекция.";

			}
		}

		public Button enterBtn;
		public TextBox widthTextBox;
		public Label text;
		public Form borderForm;
		private void changeBorderWidth_Click(object sender, EventArgs e)
		{


			// Show testDialog as a modal dialog and determine if DialogResult = OK.
			borderForm = new Form();

			borderForm.Text = "Enter border width";
			enterBtn = new Button();
			Button cancelBtn = new Button();
			widthTextBox = new TextBox();
			text = new Label();
			text.Text = "Width(1-20): ";
			enterBtn.Text = "Set Border Width";
			cancelBtn.Text = "Cancel";
			text.Location = new Point(90, 80);
			widthTextBox.Location = new Point(text.Left, text.Height + text.Top + 10);
			borderForm.Controls.Add(text);
			borderForm.Controls.Add(widthTextBox);
			enterBtn.Location = new Point(widthTextBox.Left, widthTextBox.Height + widthTextBox.Top + 10);
			cancelBtn.Location = new Point(enterBtn.Left, enterBtn.Height + enterBtn.Top + 10);
			// Set the accept button of the form to button1.
			borderForm.AcceptButton = enterBtn;
			
			// Set the cancel button of the form to button2.
			borderForm.CancelButton = cancelBtn;
			// Add enterBtn to the form.
			borderForm.Controls.Add(enterBtn);
			enterBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			// Add cancelBtn to the form.
			borderForm.Controls.Add(cancelBtn);
			borderForm.StartPosition = FormStartPosition.CenterScreen;
			borderForm.ShowDialog();
			
			enterBtn_Click(sender, e);

			
		}

		private void enterBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (widthTextBox.Text == "")
				{
					borderForm.Close();
				}
				else if ((float.Parse(widthTextBox.Text) < 0) || (float.Parse(widthTextBox.Text) > 20))
				{
					string message = "Enter appropriate value(1-20)!";
					string caption = "Error Detected in Input";
					MessageBoxButtons button = MessageBoxButtons.OK;
					DialogResult result;

					// Displays the MessageBox.
					result = MessageBox.Show(message, caption, button);
					if (result == System.Windows.Forms.DialogResult.OK)
					{

					}
				}
				else
				{

					dialogProcessor.currentWidth = float.Parse(widthTextBox.Text);
					dialogProcessor.ChangeGroupStrokeWidth(float.Parse(widthTextBox.Text));
					statusBar.Items[0].Text = "Последно действие: Задаване на дебелина на контура около фигурата.";
					viewPort.Invalidate();
				}
			}
            catch
            {
				borderForm.Close();
			}
			
		}

        private void deleteBtn_Click(object sender, EventArgs e)
        {
			dialogProcessor.DeleteSelectedShapes();
			statusBar.Items[0].Text = "Последно действие: Изтриване на селектираните фигури.";
			viewPort.Invalidate();
		}

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.DeleteSelectedShapes();
			statusBar.Items[0].Text = "Последно действие: Изтриване на селектираните фигури.";
			viewPort.Invalidate();
		}

        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.CopySelectedShapes();
			statusBar.Items[0].Text = "Последно действие: Копиране на селектираните фигури.";
			viewPort.Invalidate();
		}

        private void pasteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.PasteSelectedShapes();
			statusBar.Items[0].Text = "Последно действие: Поставяне на копирани фигури.";
			viewPort.Invalidate();
		}

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomRectangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник.";

			viewPort.Invalidate();
		}

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomEllipse();

			statusBar.Items[0].Text = "Последно действие: Рисуване на елипса.";

			viewPort.Invalidate();
		}

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomCircle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на кръг.";

			viewPort.Invalidate();
		}

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomLine();

			statusBar.Items[0].Text = "Последно действие: Рисуване на отсечка.";

			viewPort.Invalidate();
		}

        private void pointToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomPoint();

			statusBar.Items[0].Text = "Последно действие: Рисуване на точка.";

			viewPort.Invalidate();
		}

        private void selectAllShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.SelectAllShapes();
			statusBar.Items[0].Text = "Последно действие: Селекция на всички примитиви.";

			viewPort.Invalidate();
		}

        private void groupButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.GroupSelectedShapes();
			statusBar.Items[0].Text = "Последно действие: Групиране на избраните примитиви";
			viewPort.Invalidate();
		}

		//UnGroup Shapes Button - forgot to rename it
		private void toolStripButton1_Click_1(object sender, EventArgs e)
		{
			dialogProcessor.UnGroupSelectedShapes();
			statusBar.Items[0].Text = "Последно действие: Отмяна на групиране на избраните примитиви";
			viewPort.Invalidate();
		}


		public Button enterRotateBtn;
		public TextBox rotateTextBox;
		public Label textRotate;
		public Form rotateForm;

		public void RotateFormMethod(object sender, EventArgs e)
        {
			rotateForm = new Form();

			rotateForm.Text = "Enter rotate degree: ";
			enterRotateBtn = new Button();
			Button cancelRotateBtn = new Button();
			rotateTextBox = new TextBox();
			textRotate = new Label();
			textRotate.Text = "Degree(1-1000): ";
			enterRotateBtn.Text = "Set Rotate Radius";
			cancelRotateBtn.Text = "Cancel";
			textRotate.Location = new Point(90, 80);
			rotateTextBox.Location = new Point(textRotate.Left, textRotate.Height + textRotate.Top + 10);
			rotateForm.Controls.Add(textRotate);
			rotateForm.Controls.Add(rotateTextBox);
			enterRotateBtn.Location = new Point(rotateTextBox.Left, rotateTextBox.Height + rotateTextBox.Top + 10);
			cancelRotateBtn.Location = new Point(enterRotateBtn.Left, enterRotateBtn.Height + enterRotateBtn.Top + 10);
			// Set the accept button of the form to button1.
			rotateForm.AcceptButton = enterRotateBtn;

			// Set the cancel button of the form to button2.
			rotateForm.CancelButton = cancelRotateBtn;
			// Add enterBtn to the form.
			rotateForm.Controls.Add(enterRotateBtn);
			enterRotateBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			// Add cancelBtn to the form.
			rotateForm.Controls.Add(cancelRotateBtn);
			rotateForm.StartPosition = FormStartPosition.CenterScreen;
			rotateForm.ShowDialog();

			enterRotateBtn_Click(sender, e);
		}
		private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
			RotateFormMethod(sender, e);
		}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
			RotateFormMethod(sender, e);
		}

		private void enterRotateBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (rotateTextBox.Text == "")
				{
					rotateForm.Close();
				}
				else if ((float.Parse(rotateTextBox.Text) < 1) || (float.Parse(rotateTextBox.Text) > 1000))
				{
					string message = "Enter appropriate value(1-1000)!";
					string caption = "Error Detected in Input";
					MessageBoxButtons button = MessageBoxButtons.OK;
					DialogResult result;

					// Displays the MessageBox.
					result = MessageBox.Show(message, caption, button);
					if (result == System.Windows.Forms.DialogResult.OK)
					{

					}
				}
				else
				{

					dialogProcessor.RotateShape(float.Parse(rotateTextBox.Text));
					statusBar.Items[0].Text = "Последно действие: Завъртане на фигура/фигури.";
					viewPort.Invalidate();
				}
			}
			catch
			{
				rotateForm.Close();
			}

		}

        private void triangleButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomTriangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник.";

			viewPort.Invalidate();
		}

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomTriangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник.";

			viewPort.Invalidate();
		}
    }
}
