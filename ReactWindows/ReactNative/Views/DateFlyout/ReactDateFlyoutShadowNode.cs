using Facebook.Yoga;
using ReactNative.UIManager;

namespace ReactNative.Views.DateFlyout
{
    /// <summary>
    /// The shadow node implementation for <see cref="ReactNative.Views.DateFlyout.ReactDateFlyoutManager" /> views.
    /// </summary>
    public class ReactDateFlyoutShadowNode : LayoutShadowNode
    {
        /// <summary>
        /// Instantiates the <see cref="ReactDateFlyoutShadowNode"/>.
        /// </summary>
        public ReactDateFlyoutShadowNode()
        {
            MeasureFunction = MeasurePicker;
        }

        private static YogaSize MeasurePicker(YogaNode node, float width, YogaMeasureMode widthMode, float height, YogaMeasureMode heightMode)
        {
            var adjustedHeight = YogaConstants.IsUndefined(height) ? 40f : height;
            var adjustedWidth = YogaConstants.IsUndefined(width) ? 100f : width;
            return MeasureOutput.Make(adjustedWidth, adjustedHeight);
        }
    }
}
