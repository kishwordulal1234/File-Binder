using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using File_Binder.Properties;
using Microsoft.CSharp;

namespace File_Binder
{
	public class FileBinderForm : Form
	{
		private IContainer components = null;
		private ListBox fileListBox;
		private Button addButton;
		private OpenFileDialog openFileDialog;
		private Button removeButton;
		private Button bindButton;
		private Button editIconButton;
		private OpenFileDialog openFileDialog2;
		private SaveFileDialog saveFileDialog;
		private string strIconPath = "";
		private Timer fadeInTimer;
		private double formOpacity = 0.0;
		private Panel backgroundPanel;
		private PictureBox logoOverlay;
		private Label titleLabel;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileBinderForm));
			this.fileListBox = new System.Windows.Forms.ListBox();
			this.addButton = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.removeButton = new System.Windows.Forms.Button();
			this.bindButton = new System.Windows.Forms.Button();
			this.editIconButton = new System.Windows.Forms.Button();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.backgroundPanel = new System.Windows.Forms.Panel();
			this.logoOverlay = new System.Windows.Forms.PictureBox();
			this.titleLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.logoOverlay)).BeginInit();
			this.SuspendLayout();

			// backgroundPanel
			this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
			this.backgroundPanel.Name = "backgroundPanel";
			this.backgroundPanel.Size = new System.Drawing.Size(600, 450);
			this.backgroundPanel.TabIndex = 0;
			this.backgroundPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BackgroundPanel_Paint);

			// logoOverlay
			this.logoOverlay.BackColor = Color.Transparent;
			this.logoOverlay.Location = new System.Drawing.Point(180, 120);
			this.logoOverlay.Name = "logoOverlay";
			this.logoOverlay.Size = new System.Drawing.Size(240, 240);
			this.logoOverlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.logoOverlay.TabIndex = 50;
			this.logoOverlay.TabStop = false;

			// titleLabel
			this.titleLabel.AutoSize = false;
			this.titleLabel.BackColor = Color.Transparent;
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
			this.titleLabel.ForeColor = Color.White;
			this.titleLabel.Location = new System.Drawing.Point(50, 20);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(500, 50);
			this.titleLabel.TabIndex = 51;
			this.titleLabel.Text = "⚡ FILE BINDER ⚡";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			// fileListBox
			this.fileListBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 40);
			this.fileListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fileListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular);
			this.fileListBox.ForeColor = System.Drawing.Color.FromArgb(0, 255, 150);
			this.fileListBox.FormattingEnabled = true;
			this.fileListBox.ItemHeight = 14;
			this.fileListBox.Location = new System.Drawing.Point(50, 90);
			this.fileListBox.Name = "fileListBox";
			this.fileListBox.Size = new System.Drawing.Size(500, 140);
			this.fileListBox.TabIndex = 0;

			// addButton
			this.addButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 80);
			this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 150, 255);
			this.addButton.FlatAppearance.BorderSize = 2;
			this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 100, 150);
			this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(80, 80, 120);
			this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.addButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.addButton.ForeColor = System.Drawing.Color.White;
			this.addButton.Location = new System.Drawing.Point(50, 250);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(150, 45);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "➕ Add Files";
			this.addButton.UseVisualStyleBackColor = false;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			this.addButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
			this.addButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);

			// removeButton
			this.removeButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 80);
			this.removeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 100, 100);
			this.removeButton.FlatAppearance.BorderSize = 2;
			this.removeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(150, 50, 50);
			this.removeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 60, 60);
			this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.removeButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.removeButton.ForeColor = System.Drawing.Color.White;
			this.removeButton.Location = new System.Drawing.Point(225, 250);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(150, 45);
			this.removeButton.TabIndex = 2;
			this.removeButton.Text = "❌ Remove";
			this.removeButton.UseVisualStyleBackColor = false;
			this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
			this.removeButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
			this.removeButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);

			// editIconButton
			this.editIconButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 80);
			this.editIconButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 200, 100);
			this.editIconButton.FlatAppearance.BorderSize = 2;
			this.editIconButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(150, 120, 50);
			this.editIconButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 90, 60);
			this.editIconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.editIconButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.editIconButton.ForeColor = System.Drawing.Color.White;
			this.editIconButton.Location = new System.Drawing.Point(400, 250);
			this.editIconButton.Name = "editIconButton";
			this.editIconButton.Size = new System.Drawing.Size(150, 45);
			this.editIconButton.TabIndex = 3;
			this.editIconButton.Text = "🎨 Edit Icon";
			this.editIconButton.UseVisualStyleBackColor = false;
			this.editIconButton.Click += new System.EventHandler(this.editIconButton_Click);
			this.editIconButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
			this.editIconButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);

			// bindButton
			this.bindButton.BackColor = System.Drawing.Color.FromArgb(60, 80, 60);
			this.bindButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 255, 100);
			this.bindButton.FlatAppearance.BorderSize = 3;
			this.bindButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(50, 150, 50);
			this.bindButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 120, 60);
			this.bindButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bindButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.bindButton.ForeColor = System.Drawing.Color.White;
			this.bindButton.Location = new System.Drawing.Point(175, 330);
			this.bindButton.Name = "bindButton";
			this.bindButton.Size = new System.Drawing.Size(250, 60);
			this.bindButton.TabIndex = 4;
			this.bindButton.Text = "🔗 BIND FILES";
			this.bindButton.UseVisualStyleBackColor = false;
			this.bindButton.Click += new System.EventHandler(this.bindButton_Click);
			this.bindButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
			this.bindButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);

			// openFileDialog
			this.openFileDialog.Multiselect = true;
			this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);

			// openFileDialog2
			this.openFileDialog2.Filter = "Icon Files|*.ico";
			this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);

			// saveFileDialog
			this.saveFileDialog.Filter = "Executable Files|*.exe";
			this.saveFileDialog.Title = "Save Binded File";
			this.saveFileDialog.FileName = "binded.exe";

			// FileBinderForm
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(20, 20, 30);
			this.ClientSize = new System.Drawing.Size(600, 450);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.editIconButton);
			this.Controls.Add(this.bindButton);
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.fileListBox);
			this.Controls.Add(this.logoOverlay);
			this.Controls.Add(this.backgroundPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FileBinderForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "File Binder - cracked by unknone hart";
			this.Load += new System.EventHandler(this.FileBinderForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.logoOverlay)).EndInit();
			this.ResumeLayout(false);
		}

		public FileBinderForm()
		{
			InitializeComponent();
			this.Opacity = 0;
			CreateLogoImage();
		}

		private void CreateLogoImage()
		{
			try
			{
				// Try to load the image from file in the same directory
				string logoPath = Path.Combine(Application.StartupPath, "uh2006.png");

				if (File.Exists(logoPath))
				{
					// Load the actual image file
					Image originalImage = Image.FromFile(logoPath);

					// Create a semi-transparent version
					Bitmap transparentBitmap = new Bitmap(originalImage.Width, originalImage.Height);
					using (Graphics g = Graphics.FromImage(transparentBitmap))
					{
						g.SmoothingMode = SmoothingMode.AntiAlias;
						g.InterpolationMode = InterpolationMode.HighQualityBicubic;

						// Create a color matrix for transparency (20% opacity)
						ColorMatrix colorMatrix = new ColorMatrix();
						colorMatrix.Matrix33 = 0.15f; // Alpha channel (15% opacity for subtle background)

						ImageAttributes imageAttributes = new ImageAttributes();
						imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

						g.DrawImage(originalImage,
							new Rectangle(0, 0, originalImage.Width, originalImage.Height),
							0, 0, originalImage.Width, originalImage.Height,
							GraphicsUnit.Pixel, imageAttributes);
					}

					logoOverlay.Image = transparentBitmap;
					originalImage.Dispose();
				}
				else
				{
					// Fallback: Create a simple placeholder
					Bitmap bmp = new Bitmap(240, 240);
					using (Graphics g = Graphics.FromImage(bmp))
					{
						g.SmoothingMode = SmoothingMode.AntiAlias;
						g.Clear(Color.Transparent);

						using (Font font = new Font("Arial", 36, FontStyle.Bold))
						using (Brush textBrush = new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
						{
							StringFormat sf = new StringFormat();
							sf.Alignment = StringAlignment.Center;
							sf.LineAlignment = StringAlignment.Center;
							g.DrawString("UH\n2006", font, textBrush, new RectangleF(0, 0, 240, 240), sf);
						}
					}
					logoOverlay.Image = bmp;
				}
			}
			catch
			{
				// If loading fails, just leave it empty
				logoOverlay.Image = null;
			}
		}



		private void BackgroundPanel_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Rectangle rect = backgroundPanel.ClientRectangle;

			using (LinearGradientBrush brush = new LinearGradientBrush(
				rect,
				Color.FromArgb(20, 20, 30),
				Color.FromArgb(40, 20, 40),
				LinearGradientMode.ForwardDiagonal))
			{
				ColorBlend colorBlend = new ColorBlend();
				colorBlend.Colors = new Color[] {
					Color.FromArgb(15, 15, 25),
					Color.FromArgb(30, 20, 35),
					Color.FromArgb(25, 15, 30),
					Color.FromArgb(20, 20, 30)
				};
				colorBlend.Positions = new float[] { 0.0f, 0.33f, 0.66f, 1.0f };
				brush.InterpolationColors = colorBlend;
				g.FillRectangle(brush, rect);
			}
		}

		private void FileBinderForm_Load(object sender, EventArgs e)
		{
			fadeInTimer = new Timer();
			fadeInTimer.Interval = 20;
			fadeInTimer.Tick += FadeInTimer_Tick;
			fadeInTimer.Start();
		}

		private void FadeInTimer_Tick(object sender, EventArgs e)
		{
			formOpacity += 0.05;
			if (formOpacity >= 1.0)
			{
				formOpacity = 1.0;
				fadeInTimer.Stop();
			}
			this.Opacity = formOpacity;
		}

		private void Button_MouseEnter(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size + 1, btn.Font.Style);
		}

		private void Button_MouseLeave(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size - 1, btn.Font.Style);
		}

		private void openFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			foreach (string fileName in openFileDialog.FileNames)
			{
				fileListBox.Items.Add(fileName);
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			openFileDialog.ShowDialog();
		}

		private void removeButton_Click(object sender, EventArgs e)
		{
			if (fileListBox.SelectedIndex >= 0)
			{
				fileListBox.Items.RemoveAt(fileListBox.SelectedIndex);
			}
			else
			{
				MessageBox.Show("Please select a file to remove!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void bindButton_Click(object sender, EventArgs e)
		{
			if (fileListBox.Items.Count == 0)
			{
				MessageBox.Show("Please add files to bind first!", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			string outputPath = saveFileDialog.FileName;
			string text = "";
			string text2 = "";
			ResourceWriter resourceWriter = new ResourceWriter(Path.ChangeExtension(outputPath, ".Resources"));

			foreach (object item in fileListBox.Items)
			{
				FileInfo fileInfo = new FileInfo((string)item);
				string name = fileInfo.Name;
				string text3 = name + "Resource";
				string text4 = Resources.Dropcode.Replace("[FILENAME]", name);
				text4 = text4.Replace("[RESOURCENAME]", text3);
				text += text4;
				resourceWriter.AddResource(text3, File.ReadAllBytes(fileInfo.FullName));
			}
			resourceWriter.Close();

			text2 = Resources.CompileCode.Replace("[DROPCODE]", text);
			CompilerParameters compilerParameters = new CompilerParameters();
			compilerParameters.GenerateExecutable = true;
			compilerParameters.OutputAssembly = outputPath;
			compilerParameters.CompilerOptions = "/target:winexe";
			compilerParameters.EmbeddedResources.Add(Path.ChangeExtension(outputPath, ".Resources"));
			compilerParameters.ReferencedAssemblies.Add("System.dll");

			CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
			CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, text2);
			File.Delete(Path.ChangeExtension(outputPath, ".Resources"));

			if (compilerResults.Errors.Count > 0)
			{
				string errors = "";
				foreach (CompilerError error in compilerResults.Errors)
				{
					errors += error.ToString() + "\n";
				}
				MessageBox.Show(errors, "Compilation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (strIconPath != "")
			{
				File.WriteAllBytes("ResHacker.exe", Resources.ResHacker);
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				processStartInfo.FileName = "cmd.exe";
				processStartInfo.Arguments = "/c ResHacker.exe -addoverwrite \"" + outputPath + "\", \"" + outputPath + "\", \"" + strIconPath + "\", ICONGROUP, MAINICON, 0";
				processStartInfo.UseShellExecute = false;
				processStartInfo.CreateNoWindow = true;
				Process process = new Process();
				process.StartInfo = processStartInfo;
				process.Start();
				process.WaitForExit();

				string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "ResHacker*", SearchOption.TopDirectoryOnly);
				foreach (string path in files)
				{
					File.Delete(path);
				}
			}

			MessageBox.Show("Files binded successfully to:\n" + outputPath, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void editIconButton_Click(object sender, EventArgs e)
		{
			openFileDialog2.ShowDialog();
		}

		private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
		{
			strIconPath = openFileDialog2.FileName;
			MessageBox.Show("Icon selected: " + Path.GetFileName(strIconPath), "Icon Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
