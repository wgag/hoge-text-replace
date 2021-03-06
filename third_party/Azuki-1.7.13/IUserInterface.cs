// file: IUserInterface.cs
// brief: interface of user interface module (platform dependent)
//=========================================================
using System;
using System.Drawing;

namespace Sgry.Azuki
{
	using IHighlighter = Highlighter.IHighlighter;
	
	/// <summary>
	/// Interface of user interface module.
	/// </summary>
	public interface IUserInterface
	{
		#region Associated View and Document
		/// <summary>
		/// Gets or sets the document which is the current editing target.
		/// </summary>
		Document Document
		{
			get; set;
		}

		/// <summary>
		/// Gets the associated view object.
		/// </summary>
		IView View
		{
			get;
		}

		/// <summary>
		/// Gets or sets type of the view which determines how to render text content.
		/// </summary>
		ViewType ViewType
		{
			get; set;
		}
		#endregion

		#region KeyBind
		/// <summary>
		/// Reset keybind to default.
		/// </summary>
		void ResetKeyBind();

		/// <summary>
		/// Gets an action which is already associated with given key.
		/// If no action was associate with given key, returns null.
		/// </summary>
		/// <param name="keyCode">key code</param>
		ActionProc GetKeyBind( uint keyCode );

		/// <summary>
		/// Sets or removes key-bind entry.
		/// Note that giving null to action will remove the key-bind.
		/// </summary>
		/// <param name="keyCode">key code to set/remove new action</param>
		/// <param name="action">action to be associated or null in case of removing key-bind.</param>
		void SetKeyBind( uint keyCode, ActionProc action );
		#endregion

		#region Appearance
		/// <summary>
		/// Gets or sets top margin of the view in pixel.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">A negative number was set.</exception>
		int TopMargin
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets left margin of the view in pixel.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">A negative number was set.</exception>
		int LeftMargin
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets type of the indicator on the horizontal ruler.
		/// </summary>
		/// <seealso cref="HRulerIndicatorType"/>
		HRulerIndicatorType HRulerIndicatorType
		{
			get; set;
		}

		/// <summary>
		/// Updates size and position of the caret graphic.
		/// </summary>
		void UpdateCaretGraphic();

		/// <summary>
		/// Updates size and position of the caret graphic.
		/// </summary>
		void UpdateCaretGraphic( Rectangle caretRect );

		/// <summary>
		/// Sets graphic of mouse cursor.
		/// </summary>
		void SetCursorGraphic( MouseCursor cursorType );

		/// <summary>
		/// Gets or sets font to be used for displaying text.
		/// </summary>
		Font Font
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets raw font information to be used for displaying text.
		/// </summary>
		FontInfo FontInfo
		{
			get; set;
		}

		/// <summary>
		/// Color set used for displaying text.
		/// </summary>
		ColorScheme ColorScheme
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets drawing options.
		/// </summary>
		DrawingOption DrawingOption
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to show line number or not.
		/// </summary>
		bool ShowsLineNumber
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to show horizontal scroll bar or not.
		/// </summary>
		bool ShowsHScrollBar
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to show 'dirt bar' or not.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This property gets or sets whether to show 'dirt bar' or not.
		/// The dirt bar is graphically a thin bar at right end of the line number area
		/// that indicates the dirty state of each text line.
		/// The state of line is one of the following states.
		/// </para>
		/// <list type="bullet">
		///		<item>LineDirtyState.Clean: the line is not modified yet.</item>
		///		<item>LineDirtyState.Dirty: the line is modified and not saved.</item>
		///		<item>LineDirtyState.Cleaned: the line is modified but saved.</item>
		/// </list>
		/// <para>
		/// Color of each line dirty state can be customized by setting
		/// ColorScheme.DirtyLineBar, ColorScheme.CleanedLineBar.
		/// </para>
		/// </remarks>
		/// <seealso cref="Sgry.Azuki.LineDirtyState">LineDirtyState enum</seealso>
		/// <seealso cref="Sgry.Azuki.Document.GetLineDirtyState">Document.GetLineDirtyState method</seealso>
		bool ShowsDirtBar
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether the current line would be drawn with underline or not.
		/// </summary>
		bool HighlightsCurrentLine
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to highlight matched bracket or not.
		/// </summary>
		bool HighlightsMatchedBracket
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to show half-width space with special graphic or not.
		/// </summary>
		bool DrawsSpace
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to show full-width space with special graphic or not.
		/// </summary>
		bool DrawsFullWidthSpace
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to show tab character with special graphic or not.
		/// </summary>
		bool DrawsTab
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to show EOL code with special graphic or not.
		/// </summary>
		bool DrawsEolCode
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets tab width in count of space characters.
		/// </summary>
		int TabWidth
		{
			get; set;
		}

		/// <summary>
		/// Gets height of each lines in pixel.
		/// </summary>
		int LineHeight
		{
			get;
		}

		/// <summary>
		/// Gets distance between lines in pixel.
		/// </summary>
		int LineSpacing
		{
			get;
		}

		/// <summary>
		/// Sets width of the content area (including line number area).
		/// </summary>
		/// <remarks>
		/// <para>
		/// This property gets or sets width by pixel of the whole graphical area
		/// containing line number area, dirt bar area, left border, and text area.
		/// </para>
		/// <para>
		/// If you want to specify this property not by pixels but by number of characters,
		/// you can use
		/// <see cref="Sgry.Azuki.IView.HRulerUnitWidth">IView.HRulerUnitWidth</see>
		/// value as 'reasonable' avarage width of characters.
		/// </para>
		/// </remarks>
		int ViewWidth
		{
			set;
		}

		/// <summary>
		/// Invalidate graphic of whole area
		/// (force to be redrawn by next paint event message).
		/// </summary>
		void Invalidate();

		/// <summary>
		/// Invalidate graphic of the specified area
		/// (force to be redrawn by next paint event message).
		/// </summary>
		void Invalidate( Rectangle rect );
		#endregion

		#region Behavior and Modes
		/// <summary>
		/// Gets or sets whether this document is read-only or not.
		/// </summary>
		bool IsReadOnly
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether overwrite mode is enabled or not. In overwrite
		/// mode, input character will not be inserted but replaces a character
		/// at where the caret is on.
		/// </summary>
		/// <seealso cref="Sgry.Azuki.IUserInterface.OverwriteModeChanged">
		/// IUserInterface.OverwriteModeChanged event
		/// </seealso>
		bool IsOverwriteMode
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets hook delegate to execute auto-indentation.
		/// If null, auto-indentation will not be performed.
		/// </summary>
		/// <remarks>
		///   <para>
		///   This property gets or sets a delegate object to execute auto-indentation. If this
		///   property was null, no auto-indentation will be executed.
		///   </para>
		///   <para>
		///   There are some built-in auto-indentation hook delegates declared as members of
		///   <see cref="AutoIndentHooks"/> class. You can use one of them, or create your own
		///   logic. For detail of the hook mechanism, see the document of
		///   <see cref="AutoIndentHook"/>.
		///   </para>
		/// </remarks>
		/// <seealso cref="AutoIndentHook"/>
		/// <seealso cref="AutoIndentHooks"/>
		/// <seealso cref="WinForms.AzukiControl.AutoIndentHook"/>
		AutoIndentHook AutoIndentHook
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether tab characters are used for indentation,
		/// instead of space characters.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This property is a synonym of <see
		/// cref="Sgry.Azuki.IUserInterface.UsesTabForIndent">UsesTabForIndent
		/// </see> property.
		/// </para>
		/// </remarks>
		/// <seealso cref="Sgry.Azuki.IUserInterface.UsesTabForIndent">
		/// UsesTabForIndent property
		/// </seealso>
		bool ConvertsTabToSpaces
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether a tab character should be used for indentation, instead of space
		/// characters.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This property gets or sets whether tab characters are used for indentation or not. If
		/// this property is false, space characters will be used.
		/// </para>
		/// <para>
		/// This property affects every action involving indentation. Next is the list of such
		/// actions:
		/// </para>
		/// <list type="bullet">
		///		<item>
		///		Inserting an indentation character sequence (hitting the &quot;tab&quot; on your
		///		keyboard).
		///		</item>
		///		<item>
		///		Executing block-indent.
		///		</item>
		///		<item>
		///		Executing auto-indentation which requires to indent lines. An example is
		///		smart-indentation for C/C++ language. If user hits &quot;Enter&quot; key when the
		///		caret is at end of line which ends with a closing curly bracket (<c> } </c>), newly
		///		generated line will be indented.
		///		</item>
		///		<item>
		///		Pasting rectangular selection data, under specific condition. An example of the 
		///		condition is; pasting when (1) a rectangular selection contains two lines, (2) the
		///		caret is at the end of a line which is not empty, and (3) the next line is empty.
		///		In this case, an appropriate amount of whitespaces are needed to be appended to the
		///		the next (empty) line so that the second line in the rectangular selection data
		///		will be placed at the same column position as the first line.
		///		</item>
		/// </list>
		/// </remarks>
		/// <seealso cref="IUserInterface.TabWidth"/>
		/// <seealso cref="Actions.BlockIndent"/>
		/// <seealso cref="Sgry.Azuki.Actions.BlockUnIndent">
		/// Actions.BlockUnIndent action
		/// </seealso>
		/// <seealso cref="UnindentsWithBackspace"/>
		bool UsesTabForIndent
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to automatically convert an input full-width space to a space.
		/// </summary>
		bool ConvertsFullWidthSpaceToSpace
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether to reduce an indent level with Backspace key rather than removing
		/// a single space character.
		/// </summary>
		/// <remarks>
		///   <para>
		///   If this property is set to true, pressing Backspace key removes multiple space
		///   characters at once so that the indentation level of the line is decreased. Azuki
		///   performs this action only if the one character before the caret is a space and if
		///   every character between the line beginning and the caret position is a whitespace
		///   character.
		///   </para>
		///   <para>
		///   This feature is useful for editing source files in which space characters are used
		///   to make indentation. To insert space characters to make indentation by pressing Tab
		///   key, use <see cref="UsesTabForIndent"/> property.
		///   </para>
		/// </remarks>
		/// <seealso cref="UsesTabForIndent"/>
		bool UnindentsWithBackspace
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether the content should be limited to a single line.
		/// </summary>
		/// <remarks>
		///   <para>
		///   If this property was set to true, Azuki does not accept EOL characters so that the
		///   content is always consisted with just one line.
		///   </para>
		///   <para>
		///   The default value is false.
		///   </para>
		/// </remarks>
		bool IsSingleLineMode
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether Azuki is in rectangle selection mode or not.
		/// </summary>
		bool IsRectSelectMode
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets how to select text.
		/// </summary>
		TextDataType SelectionMode
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether caret behavior is 'sticky' or not.
		/// </summary>
		/// <remarks>
		///   <para>
		///   This property determines whether the caret behaves 'sticky' or not.
		///   </para>
		///   <para>
		///   Sticky caret tries to keep its desired column position unless user explicitly changes
		///   it (by hitting right or left key, for instance.) Non-sticky caret updates 'desired
		///   column position' everytime you type so moving up or down the caret never changes
		///   column position of the caret.
		///   On the other hand, sticky caret does not update desired column position by typing
		///   text (because user does not 'explicitly' changed it,) so moving up or down the caret
		///   restores the column position of it to the place where you start typing text.
		///   </para>
		/// </remarks>
		bool UsesStickyCaret
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets whether URIs in the active document
		/// should be marked automatically with built-in URI marker or not.
		/// </summary>
		/// <remarks>
		///   <para>
		///   Note that built-in URI marker marks URIs in document and then Azuki shows the URIs as
		///   'looks like URI,' but (1) clicking mouse button on them, or (2) pressing keys when
		///   the caret is at middle of a URI, makes NO ACTION BY DEFAULT. To define action on such
		///   event, programmer must implement such action as a part of  event handler of standard
		///   mouse event or keyboard event. Please refer to the
		///   <see cref="Marking">document of marking feature</see> for details.
		///   </para>
		/// </remarks>
		bool MarksUri
		{
			get; set;
		}
		#endregion

		#region Edit Actions
		/// <summary>
		/// Executes UNDO.
		/// </summary>
		void Undo();

		/// <summary>
		/// Gets whether an available UNDO action exists or not.
		/// </summary>
		bool CanUndo
		{
			get;
		}

		/// <summary>
		/// Clears all stacked edit histories in currently active document.
		/// </summary>
		/// <remarks>
		///   <para>
		///   This method clears all editing histories for
		///   UNDO or REDO action in currently active document.
		///   </para>
		/// </remarks>
		/// <seealso cref="Sgry.Azuki.WinForms.AzukiControl.ClearHistory">AzukiControl.ClearHistory method</seealso>
		void ClearHistory();

		/// <summary>
		/// Gets or sets whether the edit actions will be recorded or not.
		/// </summary>
		bool IsRecordingHistory
		{
			get; set;
		}

		/// <summary>
		/// Executes REDO.
		/// </summary>
		void Redo();

		/// <summary>
		/// Gets whether an available REDO action exists or not.
		/// </summary>
		bool CanRedo
		{
			get;
		}

		/// <summary>
		/// Executes cut action.
		/// </summary>
		void Cut();

		/// <summary>
		/// Gets whether cut action can be executed or not.
		/// </summary>
		bool CanCut
		{
			get;
		}

		/// <summary>
		/// Executes copy action.
		/// </summary>
		void Copy();

		/// <summary>
		/// Gets whether copy action can be executed or not.
		/// </summary>
		bool CanCopy
		{
			get;
		}
		
		/// <summary>
		/// Executes paste action.
		/// </summary>
		void Paste();

		/// <summary>
		/// Gets whether paste action can be executed or not.
		/// </summary>
		bool CanPaste
		{
			get;
		}

		/// <summary>
		/// Executes delete action.
		/// </summary>
		void Delete();

		/// <summary>
		/// Processes specified text as an input by user.
		/// </summary>
		/// <param name="text">The string to be processed.</param>
		/// <exception cref="System.InvalidOperationException">This object is already disposed.</exception>
		/// <exception cref="System.ArgumentNullException">Parameter 'text' is null.</exception>
		/// <remarks>
		/// <para>
		/// This method processes specified text as an input by user.
		/// Because this method is the implementation of user input,
		/// some special pre-processes will be done.
		/// The example of pre-processes are next:
		/// </para>
		/// <list type="bullet">
		///		<item>If Document.ReadOnly property is true, this method will do nothing.</item>
		///		<item>This method applies AutoIndentHook for each characters in the text.</item>
		///		<item>This method applies built-in hook processes such as converting tab to spaces.</item>
		/// </list>
		/// </remarks>
		void HandleTextInput( string text );
		#endregion

		#region Selection
		/// <summary>
		/// Gets the index of where the caret is at (in char-index).
		/// </summary>
		int CaretIndex
		{
			get;
		}

		/// <summary>
		/// Sets selection range and update the desired column.
		/// </summary>
		/// <param name="anchor">the position where the selection begins</param>
		/// <param name="caret">the position where the caret is</param>
		/// <remarks>
		///   <para>
		///   This method sets the selection range and also updates the desired column.
		///   </para>
		///   <para>
		///   Normally the caret tries to keep its x-coordinate on moving line to line unless user
		///   explicitly changes x-coordinate of it. The term 'Desired Column' means this
		///   x-coordinate which the caret tries to stick close to.
		///   </para>
		/// </remarks>
		void SetSelection( int anchor, int caret );

		/// <summary>
		/// Gets range of current selection.
		/// Note that this method does not return [anchor, caret) pair but [begin, end) pair.
		/// </summary>
		/// <param name="begin">index of where the selection begins.</param>
		/// <param name="end">index of where the selection ends (selection do not includes the char at this index).</param>
		void GetSelection( out int begin, out int end );

		/// <summary>
		/// Selects all text.
		/// </summary>
		void SelectAll();
		#endregion

		#region Content Access
		/// <summary>
		/// Gets or sets currently inputted text.
		/// </summary>
		string Text
		{
			get; set;
		}

		/// <summary>
		/// Gets number of (UTF-16) characters in the currently active document.
		/// </summary>
		int TextLength
		{
			get;
		}

		/// <summary>
		/// Gets text in the range [begin, end).
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">Specified range was invalid.</exception>
		string GetTextInRange( int begin, int end );

		/// <summary>
		/// Gets number of characters currently selected.
		/// </summary>
		/// <returns>Number of characters currently selected.</returns>
		/// <remarks>
		/// <para>
		/// This method gets number of characters currently selected,
		/// properly even if the selection mode is rectangle selection.
		/// </para>
		/// <para>
		/// Note that the difference between the end of selection and the beginning of selection
		/// is not a number of selected characters if they are selected by rectangle selection.
		/// </para>
		/// </remarks>
		int GetSelectedTextLength();

		/// <summary>
		/// Gets currently selected text.
		/// </summary>
		/// <returns>Currently selected text.</returns>
		/// <remarks>
		/// <para>
		/// This method gets currently selected text.
		/// </para>
		/// <para>
		/// If current selection is rectangle selection,
		/// return value will be a string that are consisted with selected partial lines (rows)
		/// joined with CR+LF.
		/// </para>
		/// </remarks>
		string GetSelectedText();

		/// <summary>
		/// Gets currently selected text.
		/// </summary>
		/// <returns>Currently selected text.</returns>
		/// <remarks>
		/// <para>
		/// This method gets currently selected text.
		/// </para>
		/// <para>
		/// If current selection is rectangle selection,
		/// return value will be a string that are consisted with selected partial lines (rows)
		/// joined with specified string.
		/// </para>
		/// </remarks>
		string GetSelectedText( string separator );

		/// <summary>
		/// Gets length of the specified line.
		/// </summary>
		/// <param name="lineIndex">Index of the line of which to get the length.</param>
		/// <returns>Length of the specified line in character count.</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">Specified index is out of valid range.</exception>
		int GetLineLength( int lineIndex );

		/// <summary>
		/// Gets number of lines currently inputted.
		/// </summary>
		int LineCount
		{
			get;
		}
		#endregion

		#region Position / Index Conversion
		/// <summary>
		/// Calculates screen location of the character at specified index.
		/// </summary>
		/// <returns>The location of the character at specified index.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Invalid index was given.</exception>
		Point GetPositionFromIndex( int index );

		/// <summary>
		/// Calculates screen location of the character at specified index.
		/// </summary>
		/// <returns>The location of the character at specified index.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Invalid index was given.</exception>
		Point GetPositionFromIndex( int lineIndex, int columnIndex );

		/// <summary>
		/// Gets char-index of the char at the point specified by screen location.
		/// </summary>
		/// <returns>The index of the character at specified location.</returns>
		int GetIndexFromPosition( Point pt );
		#endregion

		#region Screen Line/Column Index
		/// <summary>
		/// Gets the index of the first char in the line.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">Specified index was invalid.</exception>
		int GetLineHeadIndex( int lineIndex );

		/// <summary>
		/// Gets the index of the first char in the screen line
		/// which contains the specified char-index.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">Specified index was invalid.</exception>
		int GetLineHeadIndexFromCharIndex( int charIndex );

		/// <summary>
		/// Calculates screen line index from char-index.
		/// </summary>
		/// <param name="charIndex">The index of the line which contains the char at this parameter will be calculated.</param>
		/// <returns>The index of the line which contains the character at specified index.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Specified index was out of range.</exception>
		int GetLineIndexFromCharIndex( int charIndex );

		/// <summary>
		/// Calculates screen line/column index from char-index.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">Specified index was invalid.</exception>
		void GetLineColumnIndexFromCharIndex( int charIndex, out int lineIndex, out int columnIndex );

		/// <summary>
		/// Calculates char-index from screen line/column index.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">Specified index was invalid.</exception>
		int GetCharIndexFromLineColumnIndex( int lineIndex, int columnIndex );
		#endregion

		#region Events
		/// <summary>
		/// Occurs soon after the document's caret was moved.
		/// </summary>
		event EventHandler CaretMoved;

		/// <summary>
		/// (For internal use only) Invokes CaretMoved event.
		/// </summary>
		void InvokeCaretMoved();

		/// <summary>
		/// Occures soon after rectangular selection mode was changed.
		/// </summary>
		[Obsolete("Use Document.SelectionModeChanged event instead.", false)]
		event EventHandler IsRectSelectModeChanged;

		/// <summary>
		/// (For internal use only) Invokes IsRectSelectModeChanged event.
		/// </summary>
		[Obsolete("Use Document.InvokeSelectionModeChanged method instead.", false)]
		void InvokeIsRectSelectModeChanged();

		/// <summary>
		/// Occurs soon after the overwrite mode was changed.
		/// </summary>
		/// <seealso cref="IsOverwriteMode"/>
		event EventHandler OverwriteModeChanged;

		/// <summary>
		/// (For internal use only) Invokes OverwriteModeChanged event.
		/// </summary>
		void InvokeOverwriteModeChanged();

		/// <summary>
		/// Occurres before a screen line was drawn.
		/// </summary>
		event LineDrawEventHandler LineDrawing;

		/// <summary>
		/// Invokes LineDrawing event.
		/// </summary>
		bool InvokeLineDrawing( IGraphics g, int lineIndex, Point pos );

		/// <summary>
		/// Occurres after a screen line was drawn.
		/// </summary>
		event LineDrawEventHandler LineDrawn;

		/// <summary>
		/// Invokes LineDrawn event.
		/// </summary>
		bool InvokeLineDrawn( IGraphics g, int lineIndex, Point pos );

		/// <summary>
		/// Occurres after vertical scroll happened.
		/// </summary>
		event EventHandler VScroll;

		/// <summary>
		/// (Internal use only.) Invokes VScroll event.
		/// </summary>
		void InvokeVScroll();

		/// <summary>
		/// Occurres after horizontal scroll happened.
		/// </summary>
		event EventHandler HScroll;

		/// <summary>
		/// (Internal use only.) Invokes HScroll event.
		/// </summary>
		void InvokeHScroll();
		#endregion

		#region Scroll
		/// <summary>
		/// Scrolls a portion of the window.
		/// </summary>
		void Scroll( Rectangle rect, int vOffset, int hOffset );

		/// <summary>
		/// Scrolls to where the caret is.
		/// </summary>
		void ScrollToCaret();

		/// <summary>
		/// Updates scrollbar's range.
		/// </summary>
		void UpdateScrollBarRange();

		/// <summary>
		/// Gets or sets virtual location of currently visible area.
		/// </summary>
		Point ScrollPos
		{
			get; set;
		}
		#endregion

		#region Others
		/// <summary>
		/// Gets a graphic interface.
		/// </summary>
		IGraphics GetIGraphics();

		/// <summary>
		/// Gets or sets highlighter object to highlight currently active document
		/// or null to disable highlighting.
		/// </summary>
		/// <remarks>
		///   <para>
		///   This property gets or sets highlighter for this document.
		///   </para>
		///   <para>
		///   Highlighter objects are used to highlight syntax of documents. They implements
		///   <see cref="Sgry.Azuki.Highlighter.IHighlighter"/> interface and called
		///   <see cref="Sgry.Azuki.Highlighter.IHighlighter.Highlight(Document, ref int, ref int)"
		///   >Highlight</see> method every time slightly after user input stopped to execute own
		///   highlighting logic. If null was set to this property, highlighting feature will be
		///   disabled.
		///   </para>
		///   <para>
		///   Azuki provides some built-in highlighters. See <see cref=
		///   "Sgry.Azuki.Highlighter.Highlighters">Highlighter.Highlighters</see> class members.
		///   </para>
		///   <para>
		///   User can create and use custom highlighter object. If you want to create a
		///   keyword-based highlighter, you can extend <see cref=
		///   "Sgry.Azuki.Highlighter.KeywordHighlighter">KeywordHighlighter</see>. If you want to
		///   create not a keyword based one, create a class which implements <see cref=
		///   "Sgry.Azuki.Highlighter.IHighlighter">IHighlighter</see> and write your own
		///   highlighting logic.
		///   </para>
		/// </remarks>
		/// <seealso cref="Sgry.Azuki.Highlighter.Highlighters">Highlighter.Highlighters</seealso>
		IHighlighter Highlighter
		{
			get; set;
		}

		/// <summary>
		/// (Internal use only.) Make a highlighter run after a little moment.
		/// </summary>
		void RescheduleHighlighting();

		/// <summary>
		/// Gets whether this component has the input focus or not.
		/// </summary>
		bool Focused
		{
			get;
		}
		#endregion
	}

	/// <summary>
	/// Event handler for LineDrawing event or LineDrawn event.
	/// </summary>
	/// <param name="sender">The view object which invoked the event.</param>
	/// <param name="e">Information about the event.</param>
	/// <seealso cref="Sgry.Azuki.IUserInterface.LineDrawing">IUserInterface.LineDrawing event</seealso>
	/// <seealso cref="Sgry.Azuki.IUserInterface.LineDrawn">IUserInterface.LineDrawn event</seealso>
	public delegate void LineDrawEventHandler( object sender, LineDrawEventArgs e );

	/// <summary>
	/// Information about LineDrawing event or LineDrawn event.
	/// </summary>
	/// <seealso cref="Sgry.Azuki.LineDrawEventHandler">LineDrawEventHandler delegate</seealso>
	/// <seealso cref="Sgry.Azuki.IUserInterface.LineDrawing">IUserInterface.LineDrawing event</seealso>
	/// <seealso cref="Sgry.Azuki.IUserInterface.LineDrawn">IUserInterface.LineDrawn event</seealso>
	public class LineDrawEventArgs : EventArgs
	{
		#region Fields
		IGraphics _Graphics;
		int _LineIndex;
		Point _Position;
		bool _ShouldBeRedrawn;
		#endregion

		#region Init / Dispose
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public LineDrawEventArgs( IGraphics g, int lineIndex, Point pos )
		{
			_Graphics = g;
			_LineIndex = lineIndex;
			_Position = pos;
			_ShouldBeRedrawn = false;
		}
		#endregion

		#region Properties
		/// <summary>
		/// The graphic drawing interface currently used.
		/// </summary>
		public IGraphics Graphics
		{
			get{ return _Graphics; }
		}

		/// <summary>
		/// The index of screen line which is to be drawn, or was drawn.
		/// </summary>
		public int LineIndex
		{
			get{ return _LineIndex; }
		}

		/// <summary>
		/// Gets the top-left position of the screen line which is about to be drawn, or was drawn.
		/// </summary>
		public Point Position
		{
			get{ return _Position; }
		}

		/// <summary>
		/// Gets or sets whether graphic of the entire line
		/// should be redrawn after the event or not.
		/// </summary>
		public bool ShouldBeRedrawn
		{
			get{ return _ShouldBeRedrawn; }
			set{ _ShouldBeRedrawn = value; }
		}
		#endregion
	}
}
