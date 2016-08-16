namespace BestCS.TS
{
    /// <summary>
    /// Hit test result of <see cref="FATabStrip"/>
    /// </summary>
    public enum HitTestResult
    {
        CloseButton,
        MenuGlyph,
        TabItem,
        None
    }
    
    /// <summary>
    /// ��� ����
    /// </summary>
    public enum ThemeTypes
    {
        WindowsXP,
        Office2000,
        Office2003
    }

    /// <summary>
    /// ��������� �� ��������� � ��������� TabStrip
   /// </summary>
    public enum FATabStripItemChangeTypes
    {
        Added,
        Removed,
        Changed,
        SelectionChanged
    }
}
