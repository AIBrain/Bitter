// Copyright 2015 Rick@AIBrain.org.
// 
// This notice must be kept visible in the source.
// 
// This section of source code belongs to Rick@AIBrain.Org unless otherwise specified, or the original license has been overwritten by the automatic formatting of this code.
// Any unmodified sections of source code borrowed from other projects retain their original license and thanks goes to the Authors.
// 
// Donations and royalties can be paid via
// PayPal: paypal@aibrain.org
// bitcoin: 1Mad8TxTqxKnMiHuZxArFvX8BuFEB9nqX2
// litecoin: LeUxdU2w3o6pLZGVys5xpDZvvo8DUrjBp9
// 
// Usage of the source code or compiled binaries is AS-IS.I am not responsible for Anything You Do.
// 
// Contact me by email if you have any questions or helpful criticism.
//  
// "Bitter/AskForInput.cs" was last cleaned by Rick on 2015/09/22 at 7:07 AM

namespace Bitter {

    using System;
    using System.Windows.Forms;
    using JetBrains.Annotations;
    using Librainian.Controls;

    public partial class AskForInput : Form {

        public AskForInput( [NotNull] String question ) {
            if ( question == null ) {
                throw new ArgumentNullException( nameof( question ) );
            }
            InitializeComponent();
            this.richTextBoxQuestion.Text( question.Trim() );
        }

        [CanBeNull]
        public String Response { get; private set; }

        private void buttonOkay_Click( Object sender, EventArgs e ) {
            this.Response = this.textBoxInput.Text();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click( Object sender, EventArgs e ) {
            this.Response = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }

}
