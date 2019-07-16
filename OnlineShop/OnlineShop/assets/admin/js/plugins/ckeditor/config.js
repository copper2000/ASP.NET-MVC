/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.syntaxhighlight_lang = "csharp";
    config.syntaxhighlight_hideControls = true;
    config.language = "vi";
    config.filebrowserBrowserUrl = "/assets/admin/js/plugins/ckfinder/ckfinder.html";
    config.filebrowserImageBrowserUrl = "/assets/admin/js/plugins/ckfinder/ckfinder.html?Type=Image";
    config.filebrowserFlashBrowserUrl = "/assets/admin/js/plugins/ckfinder/ckfinder.html?Type=Flash";
    config.filebrowserUploadUrl = "/assets/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?QuickUpload&type=File";
    config.filebrowserImageUploadUrl = "/Data";
    config.filebrowserFlashUploadUrl = "/assets/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?QuickUpload&type=Flash";
    CKFinder.setupCKEditor(null, '/assets/admin/js/plugins/ckfinder/')
};
