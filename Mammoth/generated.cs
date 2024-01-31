namespace Mammoth.Couscous.org.zwobble.mammoth {
    internal interface Result<T> {
        T getValue();
        java.util.Set<string> getWarnings();
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.images {
    internal interface Image {
        java.util.Optional<string> getAltText();
        string getContentType();
        java.io.InputStream getInputStream();
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.images {
    internal class ImageConverter {
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.images {
    internal interface ImageConverter__ImgElement {
        java.util.Map<string, string> convert(Image image);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter {
        internal conversion.DocumentToHtmlOptions _options;
        internal InternalDocumentConverter(conversion.DocumentToHtmlOptions options) {
            _options = options;
        }
        public results.InternalResult<string> convertToHtml(java.io.InputStream stream) {
            return util.PassThroughException.unwrap<results.InternalResult<string>>(new InternalDocumentConverter__Anonymous_1(stream, this));
        }
        public results.InternalResult<string> convertToHtml(java.io.File file) {
            return util.PassThroughException.unwrap<results.InternalResult<string>>(new InternalDocumentConverter__Anonymous_3(file, this));
        }
        public results.InternalResult<string> convertToHtml(Mammoth.Couscous.java.util.Optional<java.nio.file.Path> path, archives.Archive zipFile) {
            Mammoth.Couscous.java.util.Optional<styles.StyleMap> styleMap = (readEmbeddedStyleMap(zipFile)).map<styles.StyleMap>(new InternalDocumentConverter__Anonymous_4());
            conversion.DocumentToHtmlOptions conversionOptions = (styleMap.map<conversion.DocumentToHtmlOptions>(new InternalDocumentConverter__Anonymous_5(this))).orElse(_options);
            return ((((docx.DocumentReader.readDocument(path, zipFile)).flatMap<Mammoth.Couscous.java.util.List<html.HtmlNode>>(new InternalDocumentConverter__Anonymous_6(conversionOptions))).map<Mammoth.Couscous.java.util.List<html.HtmlNode>>(new InternalDocumentConverter__Anonymous_7())).map<Mammoth.Couscous.java.util.List<html.HtmlNode>>(new InternalDocumentConverter__Anonymous_8())).map<string>(new InternalDocumentConverter__Anonymous_9());
        }
        public Mammoth.Couscous.java.util.Optional<string> readEmbeddedStyleMap(archives.Archive zipFile) {
            return util.PassThroughException.wrap<Mammoth.Couscous.java.util.Optional<string>>(new InternalDocumentConverter__Anonymous_10(zipFile));
        }
        public results.InternalResult<string> extractRawText(java.io.InputStream stream) {
            return util.PassThroughException.unwrap<results.InternalResult<string>>(new InternalDocumentConverter__Anonymous_12(stream, this));
        }
        public results.InternalResult<string> extractRawText(java.io.File file) {
            return util.PassThroughException.unwrap<results.InternalResult<string>>(new InternalDocumentConverter__Anonymous_14(file, this));
        }
        public results.InternalResult<string> extractRawText(Mammoth.Couscous.java.util.Optional<java.nio.file.Path> path, archives.Archive zipFile) {
            return (docx.DocumentReader.readDocument(path, zipFile)).map<string>(new InternalDocumentConverter__Anonymous_15());
        }
        public static T withDocxFile<T>(java.io.File file, Mammoth.Couscous.java.util.function.Function<archives.Archive, T> function) {
            archives.Archive zipFile = new archives.ZippedArchive(file);
            try {
                return function.apply(zipFile);
            } finally {
                zipFile.close();
            }
        }
        public static T withDocxFile<T>(java.io.InputStream stream, Mammoth.Couscous.java.util.function.Function<archives.Archive, T> function) {
            archives.Archive zipFile = archives.InMemoryArchive.fromStream(stream);
            try {
                return function.apply(zipFile);
            } finally {
                zipFile.close();
            }
        }
        public static string extractRawTextOfChildren(documents.HasChildren parent) {
            return extractRawText(parent.getChildren());
        }
        public static string extractRawText(Mammoth.Couscous.java.util.List<documents.DocumentElement> nodes) {
            return java.lang.String.join("", util.Iterables.lazyMap<documents.DocumentElement, string>(nodes, new InternalDocumentConverter__Anonymous_16()));
        }
        public static string extractRawText(documents.DocumentElement node) {
            return ((util.Casts.tryCast<documents.Text>(typeof(documents.Text), node)).map<string>(new InternalDocumentConverter__Anonymous_17())).orElseGet(new InternalDocumentConverter__Anonymous_20(node));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<archives.Archive, results.InternalResult<string>> {
        internal InternalDocumentConverter _this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        internal InternalDocumentConverter__Anonymous_0(InternalDocumentConverter this_org__zwobble__mammoth__internal__InternalDocumentConverter) {
            _this_org__zwobble__mammoth__internal__InternalDocumentConverter = this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        }
        public results.InternalResult<string> apply(archives.Archive zipFile) {
            return (_this_org__zwobble__mammoth__internal__InternalDocumentConverter).convertToHtml(java.util.Optional.empty<java.nio.file.Path>(), zipFile);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_1 : util.SupplierWithException<results.InternalResult<string>, java.io.IOException> {
        internal java.io.InputStream _stream;
        internal InternalDocumentConverter _this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        internal InternalDocumentConverter__Anonymous_1(java.io.InputStream stream, InternalDocumentConverter this_org__zwobble__mammoth__internal__InternalDocumentConverter) {
            _stream = stream;
            _this_org__zwobble__mammoth__internal__InternalDocumentConverter = this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        }
        public results.InternalResult<string> get() {
            return InternalDocumentConverter.withDocxFile<results.InternalResult<string>>(_stream, new InternalDocumentConverter__Anonymous_0(_this_org__zwobble__mammoth__internal__InternalDocumentConverter));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<archives.Archive, results.InternalResult<string>> {
        internal InternalDocumentConverter _this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        internal java.io.File _file;
        internal InternalDocumentConverter__Anonymous_2(InternalDocumentConverter this_org__zwobble__mammoth__internal__InternalDocumentConverter, java.io.File file) {
            _this_org__zwobble__mammoth__internal__InternalDocumentConverter = this_org__zwobble__mammoth__internal__InternalDocumentConverter;
            _file = file;
        }
        public results.InternalResult<string> apply(archives.Archive zipFile) {
            return (_this_org__zwobble__mammoth__internal__InternalDocumentConverter).convertToHtml(java.util.Optional.of<java.nio.file.Path>((_file).toPath()), zipFile);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_3 : util.SupplierWithException<results.InternalResult<string>, java.io.IOException> {
        internal java.io.File _file;
        internal InternalDocumentConverter _this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        internal InternalDocumentConverter__Anonymous_3(java.io.File file, InternalDocumentConverter this_org__zwobble__mammoth__internal__InternalDocumentConverter) {
            _file = file;
            _this_org__zwobble__mammoth__internal__InternalDocumentConverter = this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        }
        public results.InternalResult<string> get() {
            return InternalDocumentConverter.withDocxFile<results.InternalResult<string>>(_file, new InternalDocumentConverter__Anonymous_2(_this_org__zwobble__mammoth__internal__InternalDocumentConverter, _file));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_4 : Mammoth.Couscous.java.util.function.Function<string, styles.StyleMap> {
        public styles.StyleMap apply(string arg0) {
            return styles.parsing.StyleMapParser.parse(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_5 : Mammoth.Couscous.java.util.function.Function<styles.StyleMap, conversion.DocumentToHtmlOptions> {
        internal InternalDocumentConverter _this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        internal InternalDocumentConverter__Anonymous_5(InternalDocumentConverter this_org__zwobble__mammoth__internal__InternalDocumentConverter) {
            _this_org__zwobble__mammoth__internal__InternalDocumentConverter = this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        }
        public conversion.DocumentToHtmlOptions apply(styles.StyleMap arg0) {
            return ((_this_org__zwobble__mammoth__internal__InternalDocumentConverter)._options).addEmbeddedStyleMap(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_6 : Mammoth.Couscous.java.util.function.Function<documents.Document, results.InternalResult<Mammoth.Couscous.java.util.List<html.HtmlNode>>> {
        internal conversion.DocumentToHtmlOptions _conversionOptions;
        internal InternalDocumentConverter__Anonymous_6(conversion.DocumentToHtmlOptions conversionOptions) {
            _conversionOptions = conversionOptions;
        }
        public results.InternalResult<Mammoth.Couscous.java.util.List<html.HtmlNode>> apply(documents.Document nodes) {
            return conversion.DocumentToHtml.convertToHtml(nodes, _conversionOptions);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_7 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<html.HtmlNode>, Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        public Mammoth.Couscous.java.util.List<html.HtmlNode> apply(Mammoth.Couscous.java.util.List<html.HtmlNode> arg0) {
            return html.Html.stripEmpty(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_8 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<html.HtmlNode>, Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        public Mammoth.Couscous.java.util.List<html.HtmlNode> apply(Mammoth.Couscous.java.util.List<html.HtmlNode> arg0) {
            return html.Html.collapse(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_9 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<html.HtmlNode>, string> {
        public string apply(Mammoth.Couscous.java.util.List<html.HtmlNode> arg0) {
            return html.Html.write(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_10 : util.SupplierWithException<Mammoth.Couscous.java.util.Optional<string>, java.io.IOException> {
        internal archives.Archive _zipFile;
        internal InternalDocumentConverter__Anonymous_10(archives.Archive zipFile) {
            _zipFile = zipFile;
        }
        public Mammoth.Couscous.java.util.Optional<string> get() {
            return docx.EmbeddedStyleMap.readStyleMap(_zipFile);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_11 : Mammoth.Couscous.java.util.function.Function<archives.Archive, results.InternalResult<string>> {
        internal InternalDocumentConverter _this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        internal InternalDocumentConverter__Anonymous_11(InternalDocumentConverter this_org__zwobble__mammoth__internal__InternalDocumentConverter) {
            _this_org__zwobble__mammoth__internal__InternalDocumentConverter = this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        }
        public results.InternalResult<string> apply(archives.Archive zipFile) {
            return (_this_org__zwobble__mammoth__internal__InternalDocumentConverter).extractRawText(java.util.Optional.empty<java.nio.file.Path>(), zipFile);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_12 : util.SupplierWithException<results.InternalResult<string>, java.io.IOException> {
        internal java.io.InputStream _stream;
        internal InternalDocumentConverter _this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        internal InternalDocumentConverter__Anonymous_12(java.io.InputStream stream, InternalDocumentConverter this_org__zwobble__mammoth__internal__InternalDocumentConverter) {
            _stream = stream;
            _this_org__zwobble__mammoth__internal__InternalDocumentConverter = this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        }
        public results.InternalResult<string> get() {
            return InternalDocumentConverter.withDocxFile<results.InternalResult<string>>(_stream, new InternalDocumentConverter__Anonymous_11(_this_org__zwobble__mammoth__internal__InternalDocumentConverter));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_13 : Mammoth.Couscous.java.util.function.Function<archives.Archive, results.InternalResult<string>> {
        internal InternalDocumentConverter _this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        internal java.io.File _file;
        internal InternalDocumentConverter__Anonymous_13(InternalDocumentConverter this_org__zwobble__mammoth__internal__InternalDocumentConverter, java.io.File file) {
            _this_org__zwobble__mammoth__internal__InternalDocumentConverter = this_org__zwobble__mammoth__internal__InternalDocumentConverter;
            _file = file;
        }
        public results.InternalResult<string> apply(archives.Archive zipFile) {
            return (_this_org__zwobble__mammoth__internal__InternalDocumentConverter).extractRawText(java.util.Optional.of<java.nio.file.Path>((_file).toPath()), zipFile);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_14 : util.SupplierWithException<results.InternalResult<string>, java.io.IOException> {
        internal java.io.File _file;
        internal InternalDocumentConverter _this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        internal InternalDocumentConverter__Anonymous_14(java.io.File file, InternalDocumentConverter this_org__zwobble__mammoth__internal__InternalDocumentConverter) {
            _file = file;
            _this_org__zwobble__mammoth__internal__InternalDocumentConverter = this_org__zwobble__mammoth__internal__InternalDocumentConverter;
        }
        public results.InternalResult<string> get() {
            return InternalDocumentConverter.withDocxFile<results.InternalResult<string>>(_file, new InternalDocumentConverter__Anonymous_13(_this_org__zwobble__mammoth__internal__InternalDocumentConverter, _file));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_15 : Mammoth.Couscous.java.util.function.Function<documents.Document, string> {
        public string apply(documents.Document arg0) {
            return InternalDocumentConverter.extractRawTextOfChildren(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_16 : Mammoth.Couscous.java.util.function.Function<documents.DocumentElement, string> {
        public string apply(documents.DocumentElement node) {
            return InternalDocumentConverter.extractRawText(node);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_17 : Mammoth.Couscous.java.util.function.Function<documents.Text, string> {
        public string apply(documents.Text arg0) {
            return arg0.getValue();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_18 : Mammoth.Couscous.java.util.function.Function<documents.HasChildren, Mammoth.Couscous.java.util.List<documents.DocumentElement>> {
        public Mammoth.Couscous.java.util.List<documents.DocumentElement> apply(documents.HasChildren arg0) {
            return arg0.getChildren();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_19 : Mammoth.Couscous.java.util.function.Function<documents.Paragraph, string> {
        public string apply(documents.Paragraph paragraph) {
            return "\n\n";
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal {
    internal class InternalDocumentConverter__Anonymous_20 : Mammoth.Couscous.java.util.function.Supplier<string> {
        internal documents.DocumentElement _node;
        internal InternalDocumentConverter__Anonymous_20(documents.DocumentElement node) {
            _node = node;
        }
        public string get() {
            Mammoth.Couscous.java.util.List<documents.DocumentElement> children = ((util.Casts.tryCast<documents.HasChildren>(typeof(documents.HasChildren), _node)).map<Mammoth.Couscous.java.util.List<documents.DocumentElement>>(new InternalDocumentConverter__Anonymous_18())).orElse(util.Lists.list<documents.DocumentElement>());
            string suffix = ((util.Casts.tryCast<documents.Paragraph>(typeof(documents.Paragraph), _node)).map<string>(new InternalDocumentConverter__Anonymous_19())).orElse("");
            return InternalDocumentConverter.extractRawText(children) + suffix;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.archives {
    internal interface Archive : java.io.Closeable {
        Mammoth.Couscous.java.util.Optional<java.io.InputStream> tryGetInputStream(string name);
        bool exists(string name);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.archives {
    internal class Archives {
        public static java.io.InputStream getInputStream(Archive file, string name) {
            return (file.tryGetInputStream(name)).orElseThrow<java.io.IOException>(new Archives__Anonymous_0(name));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.archives {
    internal class Archives__Anonymous_0 : Mammoth.Couscous.java.util.function.Supplier<java.io.IOException> {
        internal string _name;
        internal Archives__Anonymous_0(string name) {
            _name = name;
        }
        public java.io.IOException get() {
            return new java.io.IOException("Missing entry in file: " + _name);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.archives {
    internal interface MutableArchive : Archive {
        void writeEntry(string path, string content);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.archives {
    internal class ZipPaths {
        public static ZipPaths__SplitPath splitPath(string path) {
            int index = path.lastIndexOf("/");
            if (index == -1) {
                return new ZipPaths__SplitPath("", path);
            } else {
                string dirname = path.Substring(0, index - 0);
                string basename = path.Substring(index + 1);
                return new ZipPaths__SplitPath(dirname, basename);
            }
        }
        public static string joinPath(string[] paths) {
            Mammoth.Couscous.java.util.List<string> nonEmptyPaths = util.Lists.eagerFilter<string>(java.util.Arrays.asList<string>(paths), new ZipPaths__Anonymous_0());
            Mammoth.Couscous.java.util.List<string> relevantPaths = new Mammoth.Couscous.java.util.ArrayList<string>();
             {
                Mammoth.Couscous.java.util.Iterator<string> _couscous_desugar_foreach_to_for0 = nonEmptyPaths.iterator();
                while (_couscous_desugar_foreach_to_for0.hasNext()) {
                    string path = _couscous_desugar_foreach_to_for0.next();
                    if (path.startsWith("/")) {
                        relevantPaths.clear();
                    }
                    relevantPaths.add(path);
                }
            }
            return java.lang.String.join("/", relevantPaths);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.archives {
    internal class ZipPaths__SplitPath {
        internal string _dirname;
        internal string _basename;
        internal ZipPaths__SplitPath(string dirname, string basename) {
            _dirname = dirname;
            _basename = basename;
        }
        public string getDirname() {
            return _dirname;
        }
        public string getBasename() {
            return _basename;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.archives {
    internal class ZipPaths__Anonymous_0 : Mammoth.Couscous.java.util.function.Predicate<string> {
        public bool test(string path) {
            return !path.isEmpty();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml {
        internal string _idPrefix;
        internal bool _preserveEmptyParagraphs;
        internal styles.StyleMap _styleMap;
        internal images.ImageConverter__ImgElement _imageConverter;
        internal Mammoth.Couscous.java.util.Map<string, documents.Comment> _comments;
        internal Mammoth.Couscous.java.util.List<documents.NoteReference> _noteReferences;
        internal Mammoth.Couscous.java.util.List<DocumentToHtml__ReferencedComment> _referencedComments;
        internal Mammoth.Couscous.java.util.Set<string> _warnings;
        internal static DocumentToHtml__Context _INITIAL_CONTEXT;
        static DocumentToHtml() {
            _INITIAL_CONTEXT = new DocumentToHtml__Context(false);
        }
        internal DocumentToHtml(DocumentToHtmlOptions options, Mammoth.Couscous.java.util.List<documents.Comment> comments) {
            _noteReferences = new Mammoth.Couscous.java.util.ArrayList<documents.NoteReference>();
            _referencedComments = new Mammoth.Couscous.java.util.ArrayList<DocumentToHtml__ReferencedComment>();
            _warnings = new Mammoth.Couscous.java.util.HashSet<string>();
            _idPrefix = options.idPrefix();
            _preserveEmptyParagraphs = options.shouldPreserveEmptyParagraphs();
            _styleMap = options.styleMap();
            _imageConverter = options.imageConverter();
            _comments = util.Maps.toMapWithKey<documents.Comment, string>(comments, new DocumentToHtml__Anonymous_0());
        }
        public static results.InternalResult<Mammoth.Couscous.java.util.List<html.HtmlNode>> convertToHtml(documents.Document document, DocumentToHtmlOptions options) {
            DocumentToHtml documentConverter = new DocumentToHtml(options, document.getComments());
            return new results.InternalResult<Mammoth.Couscous.java.util.List<html.HtmlNode>>(documentConverter.convertToHtml(document, _INITIAL_CONTEXT), documentConverter._warnings);
        }
        public static Mammoth.Couscous.java.util.List<documents.Note> findNotes(documents.Document document, java.lang.Iterable<documents.NoteReference> noteReferences) {
            return util.Lists.eagerMap<documents.NoteReference, documents.Note>(noteReferences, new DocumentToHtml__Anonymous_1(document));
        }
        public static results.InternalResult<Mammoth.Couscous.java.util.List<html.HtmlNode>> convertToHtml(documents.DocumentElement element, DocumentToHtmlOptions options) {
            DocumentToHtml documentConverter = new DocumentToHtml(options, util.Lists.list<documents.Comment>());
            return new results.InternalResult<Mammoth.Couscous.java.util.List<html.HtmlNode>>(documentConverter.convertToHtml(element, _INITIAL_CONTEXT), documentConverter._warnings);
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> convertToHtml(documents.Document document, DocumentToHtml__Context context) {
            Mammoth.Couscous.java.util.List<html.HtmlNode> mainBody = convertChildrenToHtml(document, context);
            Mammoth.Couscous.java.util.List<documents.Note> notes = findNotes(document, _noteReferences);
            Mammoth.Couscous.java.util.List<html.HtmlNode> noteNodes = notes.isEmpty() ? util.Lists.list<html.HtmlNode>() : util.Lists.list<html.HtmlNode>(html.Html.element("ol", util.Lists.eagerMap<documents.Note, html.HtmlNode>(notes, new DocumentToHtml__Anonymous_2(this, context))));
            Mammoth.Couscous.java.util.List<html.HtmlNode> commentNodes = (_referencedComments).isEmpty() ? util.Lists.list<html.HtmlNode>() : util.Lists.list<html.HtmlNode>(html.Html.element("dl", util.Lists.eagerFlatMap<DocumentToHtml__ReferencedComment, html.HtmlNode>(_referencedComments, new DocumentToHtml__Anonymous_3(this, context))));
            return util.Lists.eagerConcat<html.HtmlNode>(mainBody, noteNodes, commentNodes);
        }
        public html.HtmlNode convertToHtml(documents.Note note, DocumentToHtml__Context context) {
            string id = generateNoteHtmlId(note.getNoteType(), note.getId());
            string referenceId = generateNoteRefHtmlId(note.getNoteType(), note.getId());
            Mammoth.Couscous.java.util.List<html.HtmlNode> noteBody = convertToHtml(note.getBody(), context);
            html.HtmlNode backLink = html.Html.collapsibleElement("p", util.Lists.list<html.HtmlNode>(html.Html.text(" "), html.Html.element("a", util.Maps.map<string, string>("href", "#" + referenceId), util.Lists.list<html.HtmlNode>(html.Html.text("↑")))));
            return html.Html.element("li", util.Maps.map<string, string>("id", id), util.Lists.eagerConcat<html.HtmlNode>(noteBody, util.Lists.list<html.HtmlNode>(backLink)));
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> convertToHtml(DocumentToHtml__ReferencedComment referencedComment, DocumentToHtml__Context context) {
            string commentId = (referencedComment._comment).getCommentId();
            Mammoth.Couscous.java.util.List<html.HtmlNode> body = convertToHtml((referencedComment._comment).getBody(), context);
            html.HtmlNode backLink = html.Html.collapsibleElement("p", util.Lists.list<html.HtmlNode>(html.Html.text(" "), html.Html.element("a", util.Maps.map<string, string>("href", "#" + generateReferenceHtmlId("comment", commentId)), util.Lists.list<html.HtmlNode>(html.Html.text("↑")))));
            return util.Lists.list<html.HtmlNode>(html.Html.element("dt", util.Maps.map<string, string>("id", generateReferentHtmlId("comment", commentId)), util.Lists.list<html.HtmlNode>(html.Html.text("Comment " + referencedComment._label))), html.Html.element("dd", util.Lists.eagerConcat<html.HtmlNode>(body, util.Lists.list<html.HtmlNode>(backLink))));
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> convertToHtml(Mammoth.Couscous.java.util.List<documents.DocumentElement> elements, DocumentToHtml__Context context) {
            return util.Lists.eagerFlatMap<documents.DocumentElement, html.HtmlNode>(elements, new DocumentToHtml__Anonymous_4(this, context));
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> convertChildrenToHtml(documents.HasChildren element, DocumentToHtml__Context context) {
            return convertToHtml(element.getChildren(), context);
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> convertToHtml(documents.DocumentElement element, DocumentToHtml__Context context) {
            return element.accept<Mammoth.Couscous.java.util.List<html.HtmlNode>, DocumentToHtml__Context>(create_ElementConverterVisitor(), context);
        }
        public string generateNoteHtmlId(documents.NoteType noteType, string noteId) {
            return generateReferentHtmlId(noteTypeToIdFragment(noteType), noteId);
        }
        public string generateNoteRefHtmlId(documents.NoteType noteType, string noteId) {
            return generateReferenceHtmlId(noteTypeToIdFragment(noteType), noteId);
        }
        public string generateReferentHtmlId(string referenceType, string referenceId) {
            return generateId((referenceType + "-") + referenceId);
        }
        public string generateReferenceHtmlId(string referenceType, string referenceId) {
            return generateId((referenceType + "-ref-") + referenceId);
        }
        public string noteTypeToIdFragment(documents.NoteType noteType) {
            switch (noteType) {
                case documents.NoteType._FOOTNOTE:
                    return "footnote";
                case documents.NoteType._ENDNOTE:
                    return "endnote";
                default:
                    throw new java.lang.UnsupportedOperationException();
            }
        }
        public string generateId(string bookmarkName) {
            return _idPrefix + bookmarkName;
        }
        public DocumentToHtml__ElementConverterVisitor create_ElementConverterVisitor() {
            return new DocumentToHtml__ElementConverterVisitor(this);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__ReferencedComment {
        internal string _label;
        internal documents.Comment _comment;
        internal DocumentToHtml__ReferencedComment(string label, documents.Comment comment) {
            _label = label;
            _comment = comment;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Context {
        internal bool _isHeader;
        internal DocumentToHtml__Context(bool isHeader) {
            _isHeader = isHeader;
        }
        public DocumentToHtml__Context isHeader(bool isHeader) {
            return new DocumentToHtml__Context(isHeader);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__ElementConverterVisitor : documents.DocumentElementVisitor<Mammoth.Couscous.java.util.List<html.HtmlNode>, DocumentToHtml__Context> {
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal DocumentToHtml__ElementConverterVisitor(DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml) {
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.Paragraph paragraph, DocumentToHtml__Context context) {
            Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> children = new DocumentToHtml__Anonymous_5(_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml, paragraph, context);
            styles.HtmlPath mapping = (((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getParagraphHtmlPath(paragraph)).orElseGet(new DocumentToHtml__Anonymous_6(paragraph, _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml));
            return (mapping.wrap(children)).get();
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.Run run, DocumentToHtml__Context context) {
            Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> nodes = new DocumentToHtml__Anonymous_7(_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml, run, context);
            if (run.isSmallCaps()) {
                nodes = ((((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getSmallCaps()).orElse(styles.HtmlPath_static._EMPTY)).wrap(nodes);
            }
            if (run.isStrikethrough()) {
                nodes = ((((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getStrikethrough()).orElse(styles.HtmlPath_static.collapsibleElement("s"))).wrap(nodes);
            }
            if (run.isUnderline()) {
                nodes = ((((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getUnderline()).orElse(styles.HtmlPath_static._EMPTY)).wrap(nodes);
            }
            if (run.getVerticalAlignment() == documents.VerticalAlignment._SUBSCRIPT) {
                nodes = (styles.HtmlPath_static.collapsibleElement("sub")).wrap(nodes);
            }
            if (run.getVerticalAlignment() == documents.VerticalAlignment._SUPERSCRIPT) {
                nodes = (styles.HtmlPath_static.collapsibleElement("sup")).wrap(nodes);
            }
            if (run.isItalic()) {
                nodes = ((((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getItalic()).orElse(styles.HtmlPath_static.collapsibleElement("em"))).wrap(nodes);
            }
            if (run.isBold()) {
                nodes = ((((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getBold()).orElse(styles.HtmlPath_static.collapsibleElement("strong"))).wrap(nodes);
            }
            styles.HtmlPath mapping = (((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getRunHtmlPath(run)).orElseGet(new DocumentToHtml__Anonymous_8(run, _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml));
            return (mapping.wrap(nodes)).get();
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.Text text, DocumentToHtml__Context context) {
            if ((text.getValue()).isEmpty()) {
                return util.Lists.list<html.HtmlNode>();
            } else {
                return util.Lists.list<html.HtmlNode>(html.Html.text(text.getValue()));
            }
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.Tab tab, DocumentToHtml__Context context) {
            return util.Lists.list<html.HtmlNode>(html.Html.text("\t"));
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.Break breakElement, DocumentToHtml__Context context) {
            styles.HtmlPath mapping = (((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getBreakHtmlPath(breakElement)).orElseGet(new DocumentToHtml__Anonymous_9(breakElement));
            return (mapping.wrap(new DocumentToHtml__Anonymous_10())).get();
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.Table table, DocumentToHtml__Context context) {
            styles.HtmlPath mapping = (((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getTableHtmlPath(table)).orElse(styles.HtmlPath_static.element("table"));
            return (mapping.wrap(new DocumentToHtml__Anonymous_11(this, table, context))).get();
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> generateTableChildren(documents.Table table, DocumentToHtml__Context context) {
            int bodyIndex = (util.Iterables.findIndex<documents.DocumentElement>(table.getChildren(), new DocumentToHtml__Anonymous_12(this))).orElse((table.getChildren()).size());
            if (bodyIndex == 0) {
                return (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertToHtml(table.getChildren(), context.isHeader(false));
            } else {
                Mammoth.Couscous.java.util.List<html.HtmlNode> headRows = (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertToHtml((table.getChildren()).subList(0, bodyIndex), context.isHeader(true));
                Mammoth.Couscous.java.util.List<html.HtmlNode> bodyRows = (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertToHtml((table.getChildren()).subList(bodyIndex, (table.getChildren()).size()), context.isHeader(false));
                return util.Lists.list<html.HtmlNode>(html.Html.element("thead", headRows), html.Html.element("tbody", bodyRows));
            }
        }
        public bool isHeader(documents.DocumentElement child) {
            return ((util.Casts.tryCast<documents.TableRow>(typeof(documents.TableRow), child)).map<bool>(new DocumentToHtml__Anonymous_13())).orElse(false);
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.TableRow tableRow, DocumentToHtml__Context context) {
            return util.Lists.list<html.HtmlNode>(html.Html.element("tr", (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertChildrenToHtml(tableRow, context)));
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.TableCell tableCell, DocumentToHtml__Context context) {
            string tagName = context._isHeader ? "th" : "td";
            Mammoth.Couscous.java.util.Map<string, string> attributes = new Mammoth.Couscous.java.util.HashMap<string, string>();
            if (tableCell.getColspan() != 1) {
                attributes.put("colspan", (tableCell.getColspan()).ToString());
            }
            if (tableCell.getRowspan() != 1) {
                attributes.put("rowspan", (tableCell.getRowspan()).ToString());
            }
            return util.Lists.list<html.HtmlNode>(html.Html.element(tagName, attributes, util.Lists.cons<html.HtmlNode>(html.Html._FORCE_WRITE, (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertChildrenToHtml(tableCell, context))));
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.Hyperlink hyperlink, DocumentToHtml__Context context) {
            Mammoth.Couscous.java.util.Map<string, string> attributes = util.Maps.mutableMap<string, string>("href", generateHref(hyperlink));
            (hyperlink.getTargetFrame()).ifPresent(new DocumentToHtml__Anonymous_14(attributes));
            return util.Lists.list<html.HtmlNode>(html.Html.collapsibleElement("a", attributes, (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertChildrenToHtml(hyperlink, context)));
        }
        public string generateHref(documents.Hyperlink hyperlink) {
            if ((hyperlink.getHref()).isPresent()) {
                return (hyperlink.getHref()).get();
            } else if ((hyperlink.getAnchor()).isPresent()) {
                return "#" + (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).generateId((hyperlink.getAnchor()).get());
            } else {
                return "";
            }
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.Bookmark bookmark, DocumentToHtml__Context context) {
            return util.Lists.list<html.HtmlNode>(html.Html.element("a", util.Maps.map<string, string>("id", (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).generateId(bookmark.getName())), util.Lists.list<html.HtmlNode>(html.Html._FORCE_WRITE)));
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.NoteReference noteReference, DocumentToHtml__Context context) {
            ((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._noteReferences).add(noteReference);
            string noteAnchor = (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).generateNoteHtmlId(noteReference.getNoteType(), noteReference.getNoteId());
            string noteReferenceAnchor = (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).generateNoteRefHtmlId(noteReference.getNoteType(), noteReference.getNoteId());
            return util.Lists.list<html.HtmlNode>(html.Html.element("sup", util.Lists.list<html.HtmlNode>(html.Html.element("a", util.Maps.map<string, string>("href", "#" + noteAnchor, "id", noteReferenceAnchor), util.Lists.list<html.HtmlNode>(html.Html.text(("[" + ((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._noteReferences).size()) + "]"))))));
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.CommentReference commentReference, DocumentToHtml__Context context) {
            return (((((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._styleMap).getCommentReference()).orElse(styles.HtmlPath_static._IGNORE)).wrap(new DocumentToHtml__Anonymous_16(commentReference, _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml))).get();
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> visit(documents.Image image, DocumentToHtml__Context context) {
            return ((image.getContentType()).map<Mammoth.Couscous.java.util.List<html.HtmlNode>>(new DocumentToHtml__Anonymous_19(_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml, image))).orElse(util.Lists.list<html.HtmlNode>());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<documents.Comment, string> {
        public string apply(documents.Comment arg0) {
            return arg0.getCommentId();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<documents.NoteReference, documents.Note> {
        internal documents.Document _document;
        internal DocumentToHtml__Anonymous_1(documents.Document document) {
            _document = document;
        }
        public documents.Note apply(documents.NoteReference reference) {
            return (((_document).getNotes()).findNote(reference.getNoteType(), reference.getNoteId())).get();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<documents.Note, html.HtmlNode> {
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal DocumentToHtml__Context _context;
        internal DocumentToHtml__Anonymous_2(DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml, DocumentToHtml__Context context) {
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
            _context = context;
        }
        public html.HtmlNode apply(documents.Note note) {
            return (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertToHtml(note, _context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_3 : Mammoth.Couscous.java.util.function.Function<DocumentToHtml__ReferencedComment, java.lang.Iterable<html.HtmlNode>> {
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal DocumentToHtml__Context _context;
        internal DocumentToHtml__Anonymous_3(DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml, DocumentToHtml__Context context) {
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
            _context = context;
        }
        public java.lang.Iterable<html.HtmlNode> apply(DocumentToHtml__ReferencedComment comment) {
            return (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertToHtml(comment, _context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_4 : Mammoth.Couscous.java.util.function.Function<documents.DocumentElement, java.lang.Iterable<html.HtmlNode>> {
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal DocumentToHtml__Context _context;
        internal DocumentToHtml__Anonymous_4(DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml, DocumentToHtml__Context context) {
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
            _context = context;
        }
        public java.lang.Iterable<html.HtmlNode> apply(documents.DocumentElement element) {
            return (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertToHtml(element, _context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_5 : Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal documents.Paragraph _paragraph;
        internal DocumentToHtml__Context _context;
        internal DocumentToHtml__Anonymous_5(DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml, documents.Paragraph paragraph, DocumentToHtml__Context context) {
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
            _paragraph = paragraph;
            _context = context;
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> get() {
            Mammoth.Couscous.java.util.List<html.HtmlNode> content = (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertChildrenToHtml(_paragraph, _context);
            return (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._preserveEmptyParagraphs ? util.Lists.cons<html.HtmlNode>(html.Html._FORCE_WRITE, content) : content;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_6 : Mammoth.Couscous.java.util.function.Supplier<styles.HtmlPath> {
        internal documents.Paragraph _paragraph;
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal DocumentToHtml__Anonymous_6(documents.Paragraph paragraph, DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml) {
            _paragraph = paragraph;
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        }
        public styles.HtmlPath get() {
            if (((_paragraph).getStyle()).isPresent()) {
                ((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._warnings).add("Unrecognised paragraph style: " + (((_paragraph).getStyle()).get()).describe());
            }
            return styles.HtmlPath_static.element("p");
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_7 : Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal documents.Run _run;
        internal DocumentToHtml__Context _context;
        internal DocumentToHtml__Anonymous_7(DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml, documents.Run run, DocumentToHtml__Context context) {
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
            _run = run;
            _context = context;
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> get() {
            return (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).convertChildrenToHtml(_run, _context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_8 : Mammoth.Couscous.java.util.function.Supplier<styles.HtmlPath> {
        internal documents.Run _run;
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal DocumentToHtml__Anonymous_8(documents.Run run, DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml) {
            _run = run;
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        }
        public styles.HtmlPath get() {
            if (((_run).getStyle()).isPresent()) {
                ((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._warnings).add("Unrecognised run style: " + (((_run).getStyle()).get()).describe());
            }
            return styles.HtmlPath_static._EMPTY;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_9 : Mammoth.Couscous.java.util.function.Supplier<styles.HtmlPath> {
        internal documents.Break _breakElement;
        internal DocumentToHtml__Anonymous_9(documents.Break breakElement) {
            _breakElement = breakElement;
        }
        public styles.HtmlPath get() {
            if ((_breakElement).getType() == documents.Break__Type._LINE) {
                return styles.HtmlPath_static.element("br");
            } else {
                return styles.HtmlPath_static._EMPTY;
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_10 : Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        public Mammoth.Couscous.java.util.List<html.HtmlNode> get() {
            return util.Lists.list<html.HtmlNode>();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_11 : Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        internal DocumentToHtml__ElementConverterVisitor _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor;
        internal documents.Table _table;
        internal DocumentToHtml__Context _context;
        internal DocumentToHtml__Anonymous_11(DocumentToHtml__ElementConverterVisitor this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor, documents.Table table, DocumentToHtml__Context context) {
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor;
            _table = table;
            _context = context;
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> get() {
            return (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor).generateTableChildren(_table, _context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_12 : Mammoth.Couscous.java.util.function.Predicate<documents.DocumentElement> {
        internal DocumentToHtml__ElementConverterVisitor _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor;
        internal DocumentToHtml__Anonymous_12(DocumentToHtml__ElementConverterVisitor this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor) {
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor;
        }
        public bool test(documents.DocumentElement child) {
            return !(_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml__ElementConverterVisitor).isHeader(child);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_13 : Mammoth.Couscous.java.util.function.Function<documents.TableRow, bool> {
        public bool apply(documents.TableRow arg0) {
            return arg0.isHeader();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_14 : Mammoth.Couscous.java.util.function.Consumer<string> {
        internal Mammoth.Couscous.java.util.Map<string, string> _attributes;
        internal DocumentToHtml__Anonymous_14(Mammoth.Couscous.java.util.Map<string, string> attributes) {
            _attributes = attributes;
        }
        public void accept(string targetFrame) {
            (_attributes).put("target", targetFrame);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_15 : Mammoth.Couscous.java.util.function.Supplier<java.lang.RuntimeException> {
        internal string _commentId;
        internal DocumentToHtml__Anonymous_15(string commentId) {
            _commentId = commentId;
        }
        public java.lang.RuntimeException get() {
            return new java.lang.RuntimeException("Referenced comment could not be found, id: " + _commentId);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_16 : Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        internal documents.CommentReference _commentReference;
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal DocumentToHtml__Anonymous_16(documents.CommentReference commentReference, DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml) {
            _commentReference = commentReference;
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> get() {
            string commentId = (_commentReference).getCommentId();
            documents.Comment comment = (util.Maps.lookup<string, documents.Comment>((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._comments, commentId)).orElseThrow<java.lang.RuntimeException>(new DocumentToHtml__Anonymous_15(commentId));
            string label = (("[" + (comment.getAuthorInitials()).orElse("")) + (((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._referencedComments).size() + 1)) + "]";
            ((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._referencedComments).add(new DocumentToHtml__ReferencedComment(label, comment));
            return util.Lists.list<html.HtmlNode>(html.Html.element("a", util.Maps.map<string, string>("href", "#" + (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).generateReferentHtmlId("comment", commentId), "id", (_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml).generateReferenceHtmlId("comment", commentId)), util.Lists.list<html.HtmlNode>(html.Html.text(label))));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_17 : images.Image {
        internal documents.Image _image;
        internal string _contentType;
        internal DocumentToHtml__Anonymous_17(documents.Image image, string contentType) {
            _image = image;
            _contentType = contentType;
        }
        public Mammoth.Couscous.java.util.Optional<string> getAltText() {
            return (_image).getAltText();
        }
        public string getContentType() {
            return _contentType;
        }
        public java.io.InputStream getInputStream() {
            return (_image).open();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_18 : Mammoth.Couscous.java.util.function.Consumer<string> {
        internal Mammoth.Couscous.java.util.Map<string, string> _attributes;
        internal DocumentToHtml__Anonymous_18(Mammoth.Couscous.java.util.Map<string, string> attributes) {
            _attributes = attributes;
        }
        public void accept(string altText) {
            (_attributes).put("alt", altText);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtml__Anonymous_19 : Mammoth.Couscous.java.util.function.Function<string, Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        internal DocumentToHtml _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
        internal documents.Image _image;
        internal DocumentToHtml__Anonymous_19(DocumentToHtml this_org__zwobble__mammoth__internal__conversion__DocumentToHtml, documents.Image image) {
            _this_org__zwobble__mammoth__internal__conversion__DocumentToHtml = this_org__zwobble__mammoth__internal__conversion__DocumentToHtml;
            _image = image;
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> apply(string contentType) {
            try {
                Mammoth.Couscous.java.util.Map<string, string> attributes = new Mammoth.Couscous.java.util.HashMap<string, string>(((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._imageConverter).convert(new DocumentToHtml__Anonymous_17(_image, contentType)));
                ((_image).getAltText()).ifPresent(new DocumentToHtml__Anonymous_18(attributes));
                return util.Lists.list<html.HtmlNode>(html.Html.element("img", attributes));
            } catch (java.io.IOException exception) {
                ((_this_org__zwobble__mammoth__internal__conversion__DocumentToHtml)._warnings).add(exception.getMessage());
                return util.Lists.list<html.HtmlNode>();
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtmlOptions {
        internal static DocumentToHtmlOptions _DEFAULT;
        internal string _idPrefix;
        internal bool _preserveEmptyParagraphs;
        internal styles.StyleMap _styleMap;
        internal styles.StyleMap _embeddedStyleMap;
        internal bool _disableDefaultStyleMap;
        internal bool _disableEmbeddedStyleMap;
        internal images.ImageConverter__ImgElement _imageConverter;
        static DocumentToHtmlOptions() {
            _DEFAULT = new DocumentToHtmlOptions("", false, styles.StyleMap._EMPTY, styles.StyleMap._EMPTY, false, false, new DocumentToHtmlOptions__Anonymous_1());
        }
        internal DocumentToHtmlOptions(string idPrefix, bool preserveEmptyParagraphs, styles.StyleMap styleMap, styles.StyleMap embeddedStyleMap, bool disableDefaultStyleMap, bool disableEmbeddedStyleMap, images.ImageConverter__ImgElement imageConverter) {
            _idPrefix = idPrefix;
            _preserveEmptyParagraphs = preserveEmptyParagraphs;
            _styleMap = styleMap;
            _embeddedStyleMap = embeddedStyleMap;
            _disableDefaultStyleMap = disableDefaultStyleMap;
            _disableEmbeddedStyleMap = disableEmbeddedStyleMap;
            _imageConverter = imageConverter;
        }
        public DocumentToHtmlOptions idPrefix(string prefix) {
            return new DocumentToHtmlOptions(prefix, _preserveEmptyParagraphs, _styleMap, _embeddedStyleMap, _disableDefaultStyleMap, _disableEmbeddedStyleMap, _imageConverter);
        }
        public DocumentToHtmlOptions preserveEmptyParagraphs() {
            return new DocumentToHtmlOptions(_idPrefix, true, _styleMap, _embeddedStyleMap, _disableDefaultStyleMap, _disableEmbeddedStyleMap, _imageConverter);
        }
        public DocumentToHtmlOptions addStyleMap(string styleMap) {
            return addStyleMap(styles.parsing.StyleMapParser.parse(styleMap));
        }
        public DocumentToHtmlOptions addStyleMap(styles.StyleMap styleMap) {
            return new DocumentToHtmlOptions(_idPrefix, _preserveEmptyParagraphs, (_styleMap).update(styleMap), _embeddedStyleMap, _disableDefaultStyleMap, _disableEmbeddedStyleMap, _imageConverter);
        }
        public DocumentToHtmlOptions disableDefaultStyleMap() {
            return new DocumentToHtmlOptions(_idPrefix, _preserveEmptyParagraphs, _styleMap, _embeddedStyleMap, true, _disableEmbeddedStyleMap, _imageConverter);
        }
        public DocumentToHtmlOptions disableEmbeddedStyleMap() {
            return new DocumentToHtmlOptions(_idPrefix, _preserveEmptyParagraphs, _styleMap, _embeddedStyleMap, _disableDefaultStyleMap, true, _imageConverter);
        }
        public DocumentToHtmlOptions addEmbeddedStyleMap(styles.StyleMap embeddedStyleMap) {
            return new DocumentToHtmlOptions(_idPrefix, _preserveEmptyParagraphs, _styleMap, embeddedStyleMap, _disableDefaultStyleMap, _disableEmbeddedStyleMap, _imageConverter);
        }
        public DocumentToHtmlOptions imageConverter(images.ImageConverter__ImgElement imageConverter) {
            return new DocumentToHtmlOptions(_idPrefix, _preserveEmptyParagraphs, _styleMap, _embeddedStyleMap, _disableDefaultStyleMap, _disableEmbeddedStyleMap, imageConverter);
        }
        public string idPrefix() {
            return _idPrefix;
        }
        public bool shouldPreserveEmptyParagraphs() {
            return _preserveEmptyParagraphs;
        }
        public styles.StyleMap styleMap() {
            styles.StyleMap styleMap = styles.StyleMap._EMPTY;
            if (!_disableDefaultStyleMap) {
                styleMap = styleMap.update(styles.DefaultStyles._DEFAULT_STYLE_MAP);
            }
            if (!_disableEmbeddedStyleMap) {
                styleMap = styleMap.update(_embeddedStyleMap);
            }
            styleMap = styleMap.update(_styleMap);
            return styleMap;
        }
        public images.ImageConverter__ImgElement imageConverter() {
            return _imageConverter;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtmlOptions__Anonymous_0 : util.SupplierWithException<java.io.InputStream, java.io.IOException> {
        internal images.Image _image;
        internal DocumentToHtmlOptions__Anonymous_0(images.Image image) {
            _image = image;
        }
        public java.io.InputStream get() {
            return (_image).getInputStream();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.conversion {
    internal class DocumentToHtmlOptions__Anonymous_1 : images.ImageConverter__ImgElement {
        public Mammoth.Couscous.java.util.Map<string, string> convert(images.Image image) {
            string base64 = util.Base64Encoding.streamToBase64(new DocumentToHtmlOptions__Anonymous_0(image));
            string src = (("data:" + image.getContentType()) + ";base64,") + base64;
            return util.Maps.map<string, string>("src", src);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Bookmark : DocumentElement {
        internal string _name;
        internal Bookmark(string name) {
            _name = name;
        }
        public string getName() {
            return _name;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Break : DocumentElement {
        internal static Break _LINE_BREAK;
        internal static Break _PAGE_BREAK;
        internal static Break _COLUMN_BREAK;
        internal Break__Type _type;
        static Break() {
            _LINE_BREAK = new Break(Break__Type._LINE);
            _PAGE_BREAK = new Break(Break__Type._PAGE);
            _COLUMN_BREAK = new Break(Break__Type._COLUMN);
        }
        internal Break(Break__Type type) {
            _type = type;
        }
        public Break__Type getType() {
            return _type;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal enum Break__Type {
        _LINE, _PAGE, _COLUMN
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Comment {
        internal string _commentId;
        internal Mammoth.Couscous.java.util.List<DocumentElement> _body;
        internal Mammoth.Couscous.java.util.Optional<string> _authorName;
        internal Mammoth.Couscous.java.util.Optional<string> _authorInitials;
        internal Comment(string commentId, Mammoth.Couscous.java.util.List<DocumentElement> body, Mammoth.Couscous.java.util.Optional<string> authorName, Mammoth.Couscous.java.util.Optional<string> authorInitials) {
            _commentId = commentId;
            _body = body;
            _authorName = authorName;
            _authorInitials = authorInitials;
        }
        public string getCommentId() {
            return _commentId;
        }
        public Mammoth.Couscous.java.util.List<DocumentElement> getBody() {
            return _body;
        }
        public Mammoth.Couscous.java.util.Optional<string> getAuthorInitials() {
            return _authorInitials;
        }
        public Mammoth.Couscous.java.util.Optional<string> getAuthorName() {
            return _authorName;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class CommentReference : DocumentElement {
        internal string _commentId;
        internal CommentReference(string commentId) {
            _commentId = commentId;
        }
        public string getCommentId() {
            return _commentId;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Document : HasChildren {
        internal Mammoth.Couscous.java.util.List<DocumentElement> _children;
        internal Notes _notes;
        internal Mammoth.Couscous.java.util.List<Comment> _comments;
        internal Document(Mammoth.Couscous.java.util.List<DocumentElement> children, Notes notes, Mammoth.Couscous.java.util.List<Comment> comments) {
            _children = children;
            _notes = notes;
            _comments = comments;
        }
        public Mammoth.Couscous.java.util.List<DocumentElement> getChildren() {
            return _children;
        }
        public Notes getNotes() {
            return _notes;
        }
        public Mammoth.Couscous.java.util.List<Comment> getComments() {
            return _comments;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal interface DocumentElement {
        T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal interface DocumentElementVisitor<T, U> {
        T visit(Paragraph paragraph, U context);
        T visit(Run run, U context);
        T visit(Text text, U context);
        T visit(Tab tab, U context);
        T visit(Break lineBreak, U context);
        T visit(Table table, U context);
        T visit(TableRow tableRow, U context);
        T visit(TableCell tableCell, U context);
        T visit(Hyperlink hyperlink, U context);
        T visit(Bookmark bookmark, U context);
        T visit(NoteReference noteReference, U context);
        T visit(CommentReference commentReference, U context);
        T visit(Image image, U context);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Documents {
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal interface HasChildren {
        Mammoth.Couscous.java.util.List<DocumentElement> getChildren();
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Hyperlink : DocumentElement, HasChildren {
        internal Mammoth.Couscous.java.util.Optional<string> _href;
        internal Mammoth.Couscous.java.util.Optional<string> _anchor;
        internal Mammoth.Couscous.java.util.Optional<string> _targetFrame;
        internal Mammoth.Couscous.java.util.List<DocumentElement> _children;
        internal Hyperlink(Mammoth.Couscous.java.util.Optional<string> href, Mammoth.Couscous.java.util.Optional<string> anchor, Mammoth.Couscous.java.util.Optional<string> targetFrame, Mammoth.Couscous.java.util.List<DocumentElement> children) {
            _href = href;
            _anchor = anchor;
            _targetFrame = targetFrame;
            _children = children;
        }
        public static Hyperlink href(string href, Mammoth.Couscous.java.util.Optional<string> targetFrame, Mammoth.Couscous.java.util.List<DocumentElement> children) {
            return new Hyperlink(java.util.Optional.of<string>(href), java.util.Optional.empty<string>(), targetFrame, children);
        }
        public static Hyperlink anchor(string anchor, Mammoth.Couscous.java.util.Optional<string> targetFrame, Mammoth.Couscous.java.util.List<DocumentElement> children) {
            return new Hyperlink(java.util.Optional.empty<string>(), java.util.Optional.of<string>(anchor), targetFrame, children);
        }
        public Mammoth.Couscous.java.util.Optional<string> getHref() {
            return _href;
        }
        public Mammoth.Couscous.java.util.Optional<string> getAnchor() {
            return _anchor;
        }
        public Mammoth.Couscous.java.util.Optional<string> getTargetFrame() {
            return _targetFrame;
        }
        public Mammoth.Couscous.java.util.List<DocumentElement> getChildren() {
            return _children;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Image : DocumentElement {
        internal Mammoth.Couscous.java.util.Optional<string> _altText;
        internal Mammoth.Couscous.java.util.Optional<string> _contentType;
        internal util.InputStreamSupplier _open;
        internal Image(Mammoth.Couscous.java.util.Optional<string> altText, Mammoth.Couscous.java.util.Optional<string> contentType, util.InputStreamSupplier open) {
            _altText = altText;
            _contentType = contentType;
            _open = open;
        }
        public Mammoth.Couscous.java.util.Optional<string> getAltText() {
            return _altText;
        }
        public Mammoth.Couscous.java.util.Optional<string> getContentType() {
            return _contentType;
        }
        public java.io.InputStream open() {
            return (_open).open();
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Note {
        internal NoteType _noteType;
        internal string _id;
        internal Mammoth.Couscous.java.util.List<DocumentElement> _body;
        internal Note(NoteType noteType, string id, Mammoth.Couscous.java.util.List<DocumentElement> body) {
            _noteType = noteType;
            _id = id;
            _body = body;
        }
        public NoteType getNoteType() {
            return _noteType;
        }
        public string getId() {
            return _id;
        }
        public Mammoth.Couscous.java.util.List<DocumentElement> getBody() {
            return _body;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class NoteReference : DocumentElement {
        internal NoteType _noteType;
        internal string _noteId;
        internal NoteReference(NoteType noteType, string noteId) {
            _noteType = noteType;
            _noteId = noteId;
        }
        public static NoteReference footnoteReference(string noteId) {
            return new NoteReference(NoteType._FOOTNOTE, noteId);
        }
        public static NoteReference endnoteReference(string noteId) {
            return new NoteReference(NoteType._ENDNOTE, noteId);
        }
        public NoteType getNoteType() {
            return _noteType;
        }
        public string getNoteId() {
            return _noteId;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal enum NoteType {
        _FOOTNOTE, _ENDNOTE
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Notes {
        internal static Notes _EMPTY;
        internal Mammoth.Couscous.java.util.Map<NoteType, Mammoth.Couscous.java.util.Map<string, Note>> _notes;
        static Notes() {
            _EMPTY = new Notes(util.Lists.list<Note>());
        }
        internal Notes(Mammoth.Couscous.java.util.List<Note> notes) {
            _notes = util.Maps.eagerMapValues<NoteType, Mammoth.Couscous.java.util.List<Note>, Mammoth.Couscous.java.util.Map<string, Note>>(util.Maps.toMultiMapWithKey<Note, NoteType>(notes, new Notes__Anonymous_0()), new Notes__Anonymous_2());
        }
        public Mammoth.Couscous.java.util.Optional<Note> findNote(NoteType noteType, string noteId) {
            return (util.Maps.lookup<NoteType, Mammoth.Couscous.java.util.Map<string, Note>>(_notes, noteType)).flatMap<Note>(new Notes__Anonymous_3(noteId));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Notes__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<Note, NoteType> {
        public NoteType apply(Note arg0) {
            return arg0.getNoteType();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Notes__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<Note, string> {
        public string apply(Note arg0) {
            return arg0.getId();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Notes__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<Note>, Mammoth.Couscous.java.util.Map<string, Note>> {
        public Mammoth.Couscous.java.util.Map<string, Note> apply(Mammoth.Couscous.java.util.List<Note> notesOfType) {
            return util.Maps.toMapWithKey<Note, string>(notesOfType, new Notes__Anonymous_1());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Notes__Anonymous_3 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.Map<string, Note>, Mammoth.Couscous.java.util.Optional<Note>> {
        internal string _noteId;
        internal Notes__Anonymous_3(string noteId) {
            _noteId = noteId;
        }
        public Mammoth.Couscous.java.util.Optional<Note> apply(Mammoth.Couscous.java.util.Map<string, Note> notesOfType) {
            return util.Maps.lookup<string, Note>(notesOfType, _noteId);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class NumberingLevel {
        internal string _levelIndex;
        internal bool _isOrdered;
        internal NumberingLevel(string levelIndex, bool isOrdered) {
            _levelIndex = levelIndex;
            _isOrdered = isOrdered;
        }
        public static NumberingLevel ordered(string levelIndex) {
            return new NumberingLevel(levelIndex, true);
        }
        public static NumberingLevel unordered(string levelIndex) {
            return new NumberingLevel(levelIndex, false);
        }
        public string getLevelIndex() {
            return _levelIndex;
        }
        public bool isOrdered() {
            return _isOrdered;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Paragraph : DocumentElement, HasChildren {
        internal Mammoth.Couscous.java.util.Optional<Style> _style;
        internal Mammoth.Couscous.java.util.Optional<NumberingLevel> _numbering;
        internal ParagraphIndent _indent;
        internal Mammoth.Couscous.java.util.List<DocumentElement> _children;
        internal Paragraph(Mammoth.Couscous.java.util.Optional<Style> style, Mammoth.Couscous.java.util.Optional<NumberingLevel> numbering, ParagraphIndent indent, Mammoth.Couscous.java.util.List<DocumentElement> children) {
            _style = style;
            _numbering = numbering;
            _indent = indent;
            _children = children;
        }
        public Mammoth.Couscous.java.util.Optional<Style> getStyle() {
            return _style;
        }
        public Mammoth.Couscous.java.util.Optional<NumberingLevel> getNumbering() {
            return _numbering;
        }
        public ParagraphIndent getIndent() {
            return _indent;
        }
        public Mammoth.Couscous.java.util.List<DocumentElement> getChildren() {
            return _children;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class ParagraphIndent {
        internal Mammoth.Couscous.java.util.Optional<string> _start;
        internal Mammoth.Couscous.java.util.Optional<string> _end;
        internal Mammoth.Couscous.java.util.Optional<string> _firstLine;
        internal Mammoth.Couscous.java.util.Optional<string> _hanging;
        internal ParagraphIndent(Mammoth.Couscous.java.util.Optional<string> start, Mammoth.Couscous.java.util.Optional<string> end, Mammoth.Couscous.java.util.Optional<string> firstLine, Mammoth.Couscous.java.util.Optional<string> hanging) {
            _start = start;
            _end = end;
            _firstLine = firstLine;
            _hanging = hanging;
        }
        public Mammoth.Couscous.java.util.Optional<string> getStart() {
            return _start;
        }
        public Mammoth.Couscous.java.util.Optional<string> getEnd() {
            return _end;
        }
        public Mammoth.Couscous.java.util.Optional<string> getFirstLine() {
            return _firstLine;
        }
        public Mammoth.Couscous.java.util.Optional<string> getHanging() {
            return _hanging;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Run : DocumentElement, HasChildren {
        internal bool _isBold;
        internal bool _isItalic;
        internal bool _isUnderline;
        internal bool _isStrikethrough;
        internal bool _isSmallCaps;
        internal VerticalAlignment _verticalAlignment;
        internal Mammoth.Couscous.java.util.Optional<Style> _style;
        internal Mammoth.Couscous.java.util.List<DocumentElement> _children;
        internal Run(bool isBold, bool isItalic, bool isUnderline, bool isStrikethrough, bool isSmallCaps, VerticalAlignment verticalAlignment, Mammoth.Couscous.java.util.Optional<Style> style, Mammoth.Couscous.java.util.List<DocumentElement> children) {
            _isBold = isBold;
            _isItalic = isItalic;
            _isUnderline = isUnderline;
            _isStrikethrough = isStrikethrough;
            _isSmallCaps = isSmallCaps;
            _verticalAlignment = verticalAlignment;
            _style = style;
            _children = children;
        }
        public bool isBold() {
            return _isBold;
        }
        public bool isItalic() {
            return _isItalic;
        }
        public bool isUnderline() {
            return _isUnderline;
        }
        public bool isStrikethrough() {
            return _isStrikethrough;
        }
        public bool isSmallCaps() {
            return _isSmallCaps;
        }
        public VerticalAlignment getVerticalAlignment() {
            return _verticalAlignment;
        }
        public Mammoth.Couscous.java.util.Optional<Style> getStyle() {
            return _style;
        }
        public Mammoth.Couscous.java.util.List<DocumentElement> getChildren() {
            return _children;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Style {
        internal string _styleId;
        internal Mammoth.Couscous.java.util.Optional<string> _name;
        internal Style(string styleId, Mammoth.Couscous.java.util.Optional<string> name) {
            _styleId = styleId;
            _name = name;
        }
        public string getStyleId() {
            return _styleId;
        }
        public Mammoth.Couscous.java.util.Optional<string> getName() {
            return _name;
        }
        public string describe() {
            string styleIdDescription = "Style ID: " + _styleId;
            return ((_name).map<string>(new Style__Anonymous_0(styleIdDescription))).orElse(styleIdDescription);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Style__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<string, string> {
        internal string _styleIdDescription;
        internal Style__Anonymous_0(string styleIdDescription) {
            _styleIdDescription = styleIdDescription;
        }
        public string apply(string name) {
            return ((name + " (") + _styleIdDescription) + ")";
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Tab : DocumentElement {
        internal static Tab _TAB;
        static Tab() {
            _TAB = new Tab();
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Table : DocumentElement, HasChildren {
        internal Mammoth.Couscous.java.util.Optional<Style> _style;
        internal Mammoth.Couscous.java.util.List<DocumentElement> _children;
        internal Table(Mammoth.Couscous.java.util.Optional<Style> style, Mammoth.Couscous.java.util.List<DocumentElement> children) {
            _style = style;
            _children = children;
        }
        public Mammoth.Couscous.java.util.Optional<Style> getStyle() {
            return _style;
        }
        public Mammoth.Couscous.java.util.List<DocumentElement> getChildren() {
            return _children;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class TableCell : DocumentElement, HasChildren {
        internal int _rowspan;
        internal int _colspan;
        internal Mammoth.Couscous.java.util.List<DocumentElement> _children;
        internal TableCell(int rowspan, int colspan, Mammoth.Couscous.java.util.List<DocumentElement> children) {
            _rowspan = rowspan;
            _children = children;
            _colspan = colspan;
        }
        public int getColspan() {
            return _colspan;
        }
        public int getRowspan() {
            return _rowspan;
        }
        public Mammoth.Couscous.java.util.List<DocumentElement> getChildren() {
            return _children;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class TableRow : DocumentElement, HasChildren {
        internal Mammoth.Couscous.java.util.List<DocumentElement> _children;
        internal bool _isHeader;
        internal TableRow(Mammoth.Couscous.java.util.List<DocumentElement> children, bool isHeader) {
            _children = children;
            _isHeader = isHeader;
        }
        public Mammoth.Couscous.java.util.List<DocumentElement> getChildren() {
            return _children;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
        public bool isHeader() {
            return _isHeader;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal class Text : DocumentElement {
        internal string _value;
        internal Text(string value) {
            _value = value;
        }
        public string getValue() {
            return _value;
        }
        public T accept<T, U>(DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(this, context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.documents {
    internal enum VerticalAlignment {
        _SUPERSCRIPT, _SUBSCRIPT, _BASELINE
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class BodyXmlReader {
        internal Styles _styles;
        internal Numbering _numbering;
        internal Relationships _relationships;
        internal ContentTypes _contentTypes;
        internal archives.Archive _file;
        internal FileReader _fileReader;
        internal BodyXmlReader(Styles styles, Numbering numbering, Relationships relationships, ContentTypes contentTypes, archives.Archive file, FileReader fileReader) {
            _styles = styles;
            _numbering = numbering;
            _relationships = relationships;
            _contentTypes = contentTypes;
            _file = file;
            _fileReader = fileReader;
        }
        public ReadResult readElements(java.lang.Iterable<xml.XmlNode> nodes) {
            return (new StatefulBodyXmlReader(_styles, _numbering, _relationships, _contentTypes, _file, _fileReader)).readElements(nodes);
        }
        public ReadResult readElement(xml.XmlElement element) {
            return (new StatefulBodyXmlReader(_styles, _numbering, _relationships, _contentTypes, _file, _fileReader)).readElement(element);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class CommentXmlReader {
        internal BodyXmlReader _bodyReader;
        internal CommentXmlReader(BodyXmlReader bodyReader) {
            _bodyReader = bodyReader;
        }
        public results.InternalResult<Mammoth.Couscous.java.util.List<documents.Comment>> readElement(xml.XmlElement element) {
            return results.InternalResult.flatMap<xml.XmlElement, documents.Comment>(element.findChildren("w:comment"), new CommentXmlReader__Anonymous_0(this));
        }
        public results.InternalResult<documents.Comment> readCommentElement(xml.XmlElement element) {
            string commentId = element.getAttribute("w:id");
            return (((_bodyReader).readElements(element.getChildren())).toResult()).map<documents.Comment>(new CommentXmlReader__Anonymous_1(commentId, this, element));
        }
        public Mammoth.Couscous.java.util.Optional<string> readOptionalAttribute(xml.XmlElement element, string name) {
            string value = ((element.getAttributeOrNone(name)).orElse("")).trim();
            if (value.isEmpty()) {
                return java.util.Optional.empty<string>();
            } else {
                return java.util.Optional.of<string>(value);
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class CommentXmlReader__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, results.InternalResult<documents.Comment>> {
        internal CommentXmlReader _this_org__zwobble__mammoth__internal__docx__CommentXmlReader;
        internal CommentXmlReader__Anonymous_0(CommentXmlReader this_org__zwobble__mammoth__internal__docx__CommentXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__CommentXmlReader = this_org__zwobble__mammoth__internal__docx__CommentXmlReader;
        }
        public results.InternalResult<documents.Comment> apply(xml.XmlElement arg0) {
            return (_this_org__zwobble__mammoth__internal__docx__CommentXmlReader).readCommentElement(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class CommentXmlReader__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.Comment> {
        internal string _commentId;
        internal CommentXmlReader _this_org__zwobble__mammoth__internal__docx__CommentXmlReader;
        internal xml.XmlElement _element;
        internal CommentXmlReader__Anonymous_1(string commentId, CommentXmlReader this_org__zwobble__mammoth__internal__docx__CommentXmlReader, xml.XmlElement element) {
            _commentId = commentId;
            _this_org__zwobble__mammoth__internal__docx__CommentXmlReader = this_org__zwobble__mammoth__internal__docx__CommentXmlReader;
            _element = element;
        }
        public documents.Comment apply(Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            return new documents.Comment(_commentId, children, (_this_org__zwobble__mammoth__internal__docx__CommentXmlReader).readOptionalAttribute(_element, "w:author"), (_this_org__zwobble__mammoth__internal__docx__CommentXmlReader).readOptionalAttribute(_element, "w:initials"));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class ContentTypes {
        internal static ContentTypes _DEFAULT;
        internal static Mammoth.Couscous.java.util.Map<string, string> _imageExtensions;
        internal Mammoth.Couscous.java.util.Map<string, string> _extensionDefaults;
        internal Mammoth.Couscous.java.util.Map<string, string> _overrides;
        static ContentTypes() {
            _DEFAULT = new ContentTypes(util.Maps.map<string, string>(), util.Maps.map<string, string>());
            _imageExtensions = ((((((((util.Maps.builder<string, string>()).put("png", "png")).put("gif", "gif")).put("jpeg", "jpeg")).put("jpg", "jpeg")).put("bmp", "bmp")).put("tif", "tiff")).put("tiff", "tiff")).build();
        }
        internal ContentTypes(Mammoth.Couscous.java.util.Map<string, string> extensionDefaults, Mammoth.Couscous.java.util.Map<string, string> overrides) {
            _extensionDefaults = extensionDefaults;
            _overrides = overrides;
        }
        public Mammoth.Couscous.java.util.Optional<string> findContentType(string path) {
            if ((_overrides).containsKey(path)) {
                return util.Maps.lookup<string, string>(_overrides, path);
            } else {
                string extension = util.Paths.getExtension(path);
                if ((_extensionDefaults).containsKey(extension)) {
                    return util.Maps.lookup<string, string>(_extensionDefaults, extension);
                } else {
                    return (util.Maps.lookup<string, string>(_imageExtensions, extension.ToLower())).map<string>(new ContentTypes__Anonymous_0());
                }
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class ContentTypes__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<string, string> {
        public string apply(string imageType) {
            return "image/" + imageType;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class ContentTypesXml {
        public static ContentTypes readContentTypesXmlElement(xml.XmlElement element) {
            return new ContentTypes(readDefaults(element.findChildren("content-types:Default")), readOverrides(element.findChildren("content-types:Override")));
        }
        public static Mammoth.Couscous.java.util.Map<string, string> readDefaults(xml.XmlElementList children) {
            return util.Maps.toMap<xml.XmlElement, string, string>(children, new ContentTypesXml__Anonymous_0());
        }
        public static Mammoth.Couscous.java.util.Map__Entry<string, string> readDefault(xml.XmlElement element) {
            return util.Maps.entry<string, string>(element.getAttribute("Extension"), element.getAttribute("ContentType"));
        }
        public static Mammoth.Couscous.java.util.Map<string, string> readOverrides(xml.XmlElementList children) {
            return util.Maps.toMap<xml.XmlElement, string, string>(children, new ContentTypesXml__Anonymous_1());
        }
        public static Mammoth.Couscous.java.util.Map__Entry<string, string> readOverride(xml.XmlElement element) {
            return util.Maps.entry<string, string>(util.Strings.trimLeft(element.getAttribute("PartName"), '/'), element.getAttribute("ContentType"));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class ContentTypesXml__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Mammoth.Couscous.java.util.Map__Entry<string, string>> {
        public Mammoth.Couscous.java.util.Map__Entry<string, string> apply(xml.XmlElement arg0) {
            return ContentTypesXml.readDefault(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class ContentTypesXml__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Mammoth.Couscous.java.util.Map__Entry<string, string>> {
        public Mammoth.Couscous.java.util.Map__Entry<string, string> apply(xml.XmlElement arg0) {
            return ContentTypesXml.readOverride(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader {
        public static results.InternalResult<documents.Document> readDocument(Mammoth.Couscous.java.util.Optional<java.nio.file.Path> path, archives.Archive zipFile) {
            DocumentReader__PartPaths partPaths = findPartPaths(zipFile);
            Styles styles = readStyles(zipFile, partPaths);
            Numbering numbering = readNumbering(zipFile, partPaths);
            ContentTypes contentTypes = readContentTypes(zipFile);
            FileReader fileReader = new PathRelativeFileReader(path);
            DocumentReader__PartWithBodyReader partReader = new DocumentReader__PartWithBodyReader(zipFile, contentTypes, fileReader, numbering, styles);
            return results.InternalResult.flatMap<documents.Notes, Mammoth.Couscous.java.util.List<documents.Comment>, documents.Document>(readNotes(partReader, partPaths), readComments(partReader, partPaths), new DocumentReader__Anonymous_1(partReader, partPaths));
        }
        public static DocumentReader__PartPaths findPartPaths(archives.Archive archive) {
            Relationships packageRelationships = readPackageRelationships(archive);
            string documentFilename = findDocumentFilename(archive, packageRelationships);
            Relationships documentRelationships = readRelationships(archive, findRelationshipsPathFor(documentFilename));
            Mammoth.Couscous.java.util.function.Function<string, string> find = new DocumentReader__Anonymous_2(archive, documentRelationships, documentFilename);
            return new DocumentReader__PartPaths(documentFilename, find.apply("comments"), find.apply("endnotes"), find.apply("footnotes"), find.apply("numbering"), find.apply("styles"));
        }
        public static Relationships readPackageRelationships(archives.Archive archive) {
            return readRelationships(archive, "_rels/.rels");
        }
        public static string findDocumentFilename(archives.Archive archive, Relationships packageRelationships) {
            string officeDocumentType = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";
            string mainDocumentPath = findPartPath(archive, packageRelationships, officeDocumentType, "", "word/document.xml");
            if (archive.exists(mainDocumentPath)) {
                return mainDocumentPath;
            } else {
                throw new util.PassThroughException(new java.io.IOException("Could not find main document part. Are you sure this is a valid .docx file?"));
            }
        }
        public static string findPartPath(archives.Archive archive, Relationships relationships, string relationshipType, string basePath, string fallbackPath) {
            Mammoth.Couscous.java.util.List<string> targets = util.Lists.eagerMap<string, string>(relationships.findTargetsByType(relationshipType), new DocumentReader__Anonymous_3(basePath));
            Mammoth.Couscous.java.util.List<string> validTargets = util.Lists.eagerFilter<string>(targets, new DocumentReader__Anonymous_4(archive));
            return (util.Lists.tryGetFirst<string>(validTargets)).orElse(fallbackPath);
        }
        public static results.InternalResult<Mammoth.Couscous.java.util.List<documents.Comment>> readComments(DocumentReader__PartWithBodyReader partReader, DocumentReader__PartPaths partPaths) {
            return partReader.readPart<results.InternalResult<Mammoth.Couscous.java.util.List<documents.Comment>>>(partPaths.getComments(), new DocumentReader__Anonymous_5(), java.util.Optional.of<results.InternalResult<Mammoth.Couscous.java.util.List<documents.Comment>>>(results.InternalResult.success<Mammoth.Couscous.java.util.List<documents.Comment>>(util.Lists.list<documents.Comment>())));
        }
        public static results.InternalResult<documents.Notes> readNotes(DocumentReader__PartWithBodyReader partReader, DocumentReader__PartPaths partPaths) {
            return (results.InternalResult.map<Mammoth.Couscous.java.util.List<documents.Note>, Mammoth.Couscous.java.util.List<documents.Note>, Mammoth.Couscous.java.util.List<documents.Note>>(partReader.readPart<results.InternalResult<Mammoth.Couscous.java.util.List<documents.Note>>>(partPaths.getFootnotes(), new DocumentReader__Anonymous_6(), java.util.Optional.of<results.InternalResult<Mammoth.Couscous.java.util.List<documents.Note>>>(results.InternalResult.success<Mammoth.Couscous.java.util.List<documents.Note>>(util.Lists.list<documents.Note>()))), partReader.readPart<results.InternalResult<Mammoth.Couscous.java.util.List<documents.Note>>>(partPaths.getEndnotes(), new DocumentReader__Anonymous_7(), java.util.Optional.of<results.InternalResult<Mammoth.Couscous.java.util.List<documents.Note>>>(results.InternalResult.success<Mammoth.Couscous.java.util.List<documents.Note>>(util.Lists.list<documents.Note>()))), new DocumentReader__Anonymous_8())).map<documents.Notes>(new DocumentReader__Anonymous_9());
        }
        public static Styles readStyles(archives.Archive file, DocumentReader__PartPaths partPaths) {
            return ((tryParseOfficeXml(file, partPaths.getStyles())).map<Styles>(new DocumentReader__Anonymous_10())).orElse(Styles._EMPTY);
        }
        public static Numbering readNumbering(archives.Archive file, DocumentReader__PartPaths partPaths) {
            return ((tryParseOfficeXml(file, partPaths.getNumbering())).map<Numbering>(new DocumentReader__Anonymous_11())).orElse(Numbering._EMPTY);
        }
        public static ContentTypes readContentTypes(archives.Archive file) {
            return ((tryParseOfficeXml(file, "[Content_Types].xml")).map<ContentTypes>(new DocumentReader__Anonymous_12())).orElse(ContentTypes._DEFAULT);
        }
        public static Relationships readRelationships(archives.Archive zipFile, string name) {
            return ((tryParseOfficeXml(zipFile, name)).map<Relationships>(new DocumentReader__Anonymous_13())).orElse(Relationships._EMPTY);
        }
        public static string findRelationshipsPathFor(string name) {
            archives.ZipPaths__SplitPath parts = archives.ZipPaths.splitPath(name);
            return archives.ZipPaths.joinPath(new string[] {parts.getDirname(), "_rels", parts.getBasename() + ".rels"});
        }
        public static Mammoth.Couscous.java.util.Optional<xml.XmlElement> tryParseOfficeXml(archives.Archive zipFile, string name) {
            return util.PassThroughException.wrap<Mammoth.Couscous.java.util.Optional<xml.XmlElement>>(new DocumentReader__Anonymous_15(zipFile, name));
        }
        public static xml.XmlElement parseOfficeXml(archives.Archive zipFile, string name) {
            return (tryParseOfficeXml(zipFile, name)).orElseThrow<util.PassThroughException>(new DocumentReader__Anonymous_16(name));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__PartWithBodyReader {
        internal archives.Archive _zipFile;
        internal ContentTypes _contentTypes;
        internal FileReader _fileReader;
        internal Numbering _numbering;
        internal Styles _styles;
        internal DocumentReader__PartWithBodyReader(archives.Archive zipFile, ContentTypes contentTypes, FileReader fileReader, Numbering numbering, Styles styles) {
            _zipFile = zipFile;
            _contentTypes = contentTypes;
            _fileReader = fileReader;
            _numbering = numbering;
            _styles = styles;
        }
        public T readPart<T>(string name, Mammoth.Couscous.java.util.function.BiFunction<xml.XmlElement, BodyXmlReader, T> readPart, Mammoth.Couscous.java.util.Optional<T> defaultValue) {
            Relationships relationships = DocumentReader.readRelationships(_zipFile, DocumentReader.findRelationshipsPathFor(name));
            BodyXmlReader bodyReader = new BodyXmlReader(_styles, _numbering, relationships, _contentTypes, _zipFile, _fileReader);
            if (defaultValue.isPresent()) {
                return ((DocumentReader.tryParseOfficeXml(_zipFile, name)).map<T>(new DocumentReader__Anonymous_17<T>(readPart, bodyReader))).orElse(defaultValue.get());
            } else {
                return readPart.apply(DocumentReader.parseOfficeXml(_zipFile, name), bodyReader);
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__PartPaths {
        internal string _mainDocument;
        internal string _comments;
        internal string _endnotes;
        internal string _footnotes;
        internal string _numbering;
        internal string _styles;
        internal DocumentReader__PartPaths(string mainDocument, string comments, string endnotes, string footnotes, string numbering, string styles) {
            _mainDocument = mainDocument;
            _comments = comments;
            _endnotes = endnotes;
            _footnotes = footnotes;
            _numbering = numbering;
            _styles = styles;
        }
        public string getMainDocument() {
            return _mainDocument;
        }
        public string getComments() {
            return _comments;
        }
        public string getEndnotes() {
            return _endnotes;
        }
        public string getFootnotes() {
            return _footnotes;
        }
        public string getNumbering() {
            return _numbering;
        }
        public string getStyles() {
            return _styles;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_0 : Mammoth.Couscous.java.util.function.BiFunction<xml.XmlElement, BodyXmlReader, results.InternalResult<documents.Document>> {
        internal documents.Notes _notes;
        internal Mammoth.Couscous.java.util.List<documents.Comment> _comments;
        internal DocumentReader__Anonymous_0(documents.Notes notes, Mammoth.Couscous.java.util.List<documents.Comment> comments) {
            _notes = notes;
            _comments = comments;
        }
        public results.InternalResult<documents.Document> apply(xml.XmlElement element, BodyXmlReader bodyReader) {
            return (new DocumentXmlReader(bodyReader, _notes, _comments)).readElement(element);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_1 : Mammoth.Couscous.java.util.function.BiFunction<documents.Notes, Mammoth.Couscous.java.util.List<documents.Comment>, results.InternalResult<documents.Document>> {
        internal DocumentReader__PartWithBodyReader _partReader;
        internal DocumentReader__PartPaths _partPaths;
        internal DocumentReader__Anonymous_1(DocumentReader__PartWithBodyReader partReader, DocumentReader__PartPaths partPaths) {
            _partReader = partReader;
            _partPaths = partPaths;
        }
        public results.InternalResult<documents.Document> apply(documents.Notes notes, Mammoth.Couscous.java.util.List<documents.Comment> comments) {
            return (_partReader).readPart<results.InternalResult<documents.Document>>((_partPaths).getMainDocument(), new DocumentReader__Anonymous_0(notes, comments), java.util.Optional.empty<results.InternalResult<documents.Document>>());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<string, string> {
        internal archives.Archive _archive;
        internal Relationships _documentRelationships;
        internal string _documentFilename;
        internal DocumentReader__Anonymous_2(archives.Archive archive, Relationships documentRelationships, string documentFilename) {
            _archive = archive;
            _documentRelationships = documentRelationships;
            _documentFilename = documentFilename;
        }
        public string apply(string name) {
            return DocumentReader.findPartPath(_archive, _documentRelationships, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/" + name, (archives.ZipPaths.splitPath(_documentFilename)).getDirname(), ("word/" + name) + ".xml");
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_3 : Mammoth.Couscous.java.util.function.Function<string, string> {
        internal string _basePath;
        internal DocumentReader__Anonymous_3(string basePath) {
            _basePath = basePath;
        }
        public string apply(string target) {
            return util.Strings.trimLeft(archives.ZipPaths.joinPath(new string[] {_basePath, target}), '/');
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_4 : Mammoth.Couscous.java.util.function.Predicate<string> {
        internal archives.Archive _archive;
        internal DocumentReader__Anonymous_4(archives.Archive archive) {
            _archive = archive;
        }
        public bool test(string arg0) {
            return (_archive).exists(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_5 : Mammoth.Couscous.java.util.function.BiFunction<xml.XmlElement, BodyXmlReader, results.InternalResult<Mammoth.Couscous.java.util.List<documents.Comment>>> {
        public results.InternalResult<Mammoth.Couscous.java.util.List<documents.Comment>> apply(xml.XmlElement root, BodyXmlReader bodyReader) {
            return (new CommentXmlReader(bodyReader)).readElement(root);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_6 : Mammoth.Couscous.java.util.function.BiFunction<xml.XmlElement, BodyXmlReader, results.InternalResult<Mammoth.Couscous.java.util.List<documents.Note>>> {
        public results.InternalResult<Mammoth.Couscous.java.util.List<documents.Note>> apply(xml.XmlElement root, BodyXmlReader bodyReader) {
            return (NotesXmlReader.footnote(bodyReader)).readElement(root);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_7 : Mammoth.Couscous.java.util.function.BiFunction<xml.XmlElement, BodyXmlReader, results.InternalResult<Mammoth.Couscous.java.util.List<documents.Note>>> {
        public results.InternalResult<Mammoth.Couscous.java.util.List<documents.Note>> apply(xml.XmlElement root, BodyXmlReader bodyReader) {
            return (NotesXmlReader.endnote(bodyReader)).readElement(root);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_8 : Mammoth.Couscous.java.util.function.BiFunction<Mammoth.Couscous.java.util.List<documents.Note>, Mammoth.Couscous.java.util.List<documents.Note>, Mammoth.Couscous.java.util.List<documents.Note>> {
        public Mammoth.Couscous.java.util.List<documents.Note> apply(Mammoth.Couscous.java.util.List<documents.Note> arg0, Mammoth.Couscous.java.util.List<documents.Note> arg1) {
            return util.Lists.eagerConcat(arg0, arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_9 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.Note>, documents.Notes> {
        public documents.Notes apply(Mammoth.Couscous.java.util.List<documents.Note> arg0) {
            return new documents.Notes(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_10 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Styles> {
        public Styles apply(xml.XmlElement arg0) {
            return StylesXml.readStylesXmlElement(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_11 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Numbering> {
        public Numbering apply(xml.XmlElement arg0) {
            return NumberingXml.readNumberingXmlElement(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_12 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, ContentTypes> {
        public ContentTypes apply(xml.XmlElement arg0) {
            return ContentTypesXml.readContentTypesXmlElement(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_13 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Relationships> {
        public Relationships apply(xml.XmlElement arg0) {
            return RelationshipsXml.readRelationshipsXmlElement(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_14 : Mammoth.Couscous.java.util.function.Function<java.io.InputStream, xml.XmlElement> {
        public xml.XmlElement apply(java.io.InputStream arg0) {
            return OfficeXml.parseXml(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_15 : util.SupplierWithException<Mammoth.Couscous.java.util.Optional<xml.XmlElement>, java.io.IOException> {
        internal archives.Archive _zipFile;
        internal string _name;
        internal DocumentReader__Anonymous_15(archives.Archive zipFile, string name) {
            _zipFile = zipFile;
            _name = name;
        }
        public Mammoth.Couscous.java.util.Optional<xml.XmlElement> get() {
            return ((_zipFile).tryGetInputStream(_name)).map<xml.XmlElement>(new DocumentReader__Anonymous_14());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_16 : Mammoth.Couscous.java.util.function.Supplier<util.PassThroughException> {
        internal string _name;
        internal DocumentReader__Anonymous_16(string name) {
            _name = name;
        }
        public util.PassThroughException get() {
            return new util.PassThroughException(new java.io.IOException("Missing entry in file: " + _name));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal static class DocumentReader__Anonymous_17 {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentReader__Anonymous_17<T> : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, T> {
        internal Mammoth.Couscous.java.util.function.BiFunction<xml.XmlElement, BodyXmlReader, T> _readPart;
        internal BodyXmlReader _bodyReader;
        internal DocumentReader__Anonymous_17(Mammoth.Couscous.java.util.function.BiFunction<xml.XmlElement, BodyXmlReader, T> readPart, BodyXmlReader bodyReader) {
            _readPart = readPart;
            _bodyReader = bodyReader;
        }
        public T apply(xml.XmlElement root) {
            return (_readPart).apply(root, _bodyReader);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentXmlReader {
        internal BodyXmlReader _bodyReader;
        internal documents.Notes _notes;
        internal Mammoth.Couscous.java.util.List<documents.Comment> _comments;
        internal DocumentXmlReader(BodyXmlReader bodyReader, documents.Notes notes, Mammoth.Couscous.java.util.List<documents.Comment> comments) {
            _bodyReader = bodyReader;
            _notes = notes;
            _comments = comments;
        }
        public results.InternalResult<documents.Document> readElement(xml.XmlElement element) {
            xml.XmlElementLike body = element.findChildOrEmpty("w:body");
            return (((_bodyReader).readElements(body.getChildren())).toResult()).map<documents.Document>(new DocumentXmlReader__Anonymous_0(this));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class DocumentXmlReader__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.Document> {
        internal DocumentXmlReader _this_org__zwobble__mammoth__internal__docx__DocumentXmlReader;
        internal DocumentXmlReader__Anonymous_0(DocumentXmlReader this_org__zwobble__mammoth__internal__docx__DocumentXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__DocumentXmlReader = this_org__zwobble__mammoth__internal__docx__DocumentXmlReader;
        }
        public documents.Document apply(Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            return new documents.Document(children, (_this_org__zwobble__mammoth__internal__docx__DocumentXmlReader)._notes, (_this_org__zwobble__mammoth__internal__docx__DocumentXmlReader)._comments);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class EmbeddedStyleMap {
        internal static string _STYLE_MAP_PATH;
        internal static string _ABSOLUTE_STYLE_MAP_PATH;
        internal static string _RELATIONSHIPS_PATH;
        internal static string _CONTENT_TYPES_PATH;
        internal static xml.NamespacePrefixes _RELATIONSHIPS_NAMESPACES;
        internal static xml.NamespacePrefixes _CONTENT_TYPES_NAMESPACES;
        static EmbeddedStyleMap() {
            _STYLE_MAP_PATH = "mammoth/style-map";
            _ABSOLUTE_STYLE_MAP_PATH = "/" + _STYLE_MAP_PATH;
            _RELATIONSHIPS_PATH = "word/_rels/document.xml.rels";
            _CONTENT_TYPES_PATH = "[Content_Types].xml";
            _RELATIONSHIPS_NAMESPACES = ((xml.NamespacePrefixes.builder()).defaultPrefix("http://schemas.openxmlformats.org/package/2006/relationships")).build();
            _CONTENT_TYPES_NAMESPACES = ((xml.NamespacePrefixes.builder()).defaultPrefix("http://schemas.openxmlformats.org/package/2006/content-types")).build();
        }
        public static Mammoth.Couscous.java.util.Optional<string> readStyleMap(archives.Archive file) {
            return (file.tryGetInputStream(_STYLE_MAP_PATH)).map<string>(new EmbeddedStyleMap__Anonymous_0());
        }
        public static void embedStyleMap(archives.MutableArchive archive, string styleMap) {
            archive.writeEntry(_STYLE_MAP_PATH, styleMap);
            updateRelationships(archive);
            updateContentTypes(archive);
        }
        public static void updateRelationships(archives.MutableArchive archive) {
            xml.parsing.XmlParser parser = new xml.parsing.XmlParser(_RELATIONSHIPS_NAMESPACES);
            xml.XmlElement relationships = parser.parseStream(archives.Archives.getInputStream(archive, _RELATIONSHIPS_PATH));
            xml.XmlElement relationship = xml.XmlNodes.element("Relationship", util.Maps.map<string, string>("Id", "rMammothStyleMap", "Type", "http://schemas.zwobble.org/mammoth/style-map", "Target", _ABSOLUTE_STYLE_MAP_PATH));
            xml.XmlElement updatedRelationships = updateOrAddElement(relationships, relationship, "Id");
            archive.writeEntry(_RELATIONSHIPS_PATH, xml.XmlWriter.toString(updatedRelationships, _RELATIONSHIPS_NAMESPACES));
        }
        public static void updateContentTypes(archives.MutableArchive archive) {
            xml.parsing.XmlParser parser = new xml.parsing.XmlParser(_CONTENT_TYPES_NAMESPACES);
            xml.XmlElement contentTypes = parser.parseStream(archives.Archives.getInputStream(archive, _CONTENT_TYPES_PATH));
            xml.XmlElement @override = xml.XmlNodes.element("Override", util.Maps.map<string, string>("PartName", _ABSOLUTE_STYLE_MAP_PATH, "ContentType", "text/prs.mammoth.style-map"));
            xml.XmlElement updatedRelationships = updateOrAddElement(contentTypes, @override, "PartName");
            archive.writeEntry(_CONTENT_TYPES_PATH, xml.XmlWriter.toString(updatedRelationships, _CONTENT_TYPES_NAMESPACES));
        }
        public static xml.XmlElement updateOrAddElement(xml.XmlElement parent, xml.XmlElement element, string identifyingAttribute) {
            Mammoth.Couscous.java.util.OptionalInt index = util.Iterables.findIndex<xml.XmlNode>(parent.getChildren(), new EmbeddedStyleMap__Anonymous_2(element, identifyingAttribute));
            Mammoth.Couscous.java.util.List<xml.XmlNode> children = new Mammoth.Couscous.java.util.ArrayList<xml.XmlNode>(parent.getChildren());
            if (index.isPresent()) {
                children.set(index.getAsInt(), element);
            } else {
                children.add(element);
            }
            return new xml.XmlElement(parent.getName(), parent.getAttributes(), children);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class EmbeddedStyleMap__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<java.io.InputStream, string> {
        public string apply(java.io.InputStream arg0) {
            return util.Streams.toString(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class EmbeddedStyleMap__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, bool> {
        internal xml.XmlElement _element;
        internal string _identifyingAttribute;
        internal EmbeddedStyleMap__Anonymous_1(xml.XmlElement element, string identifyingAttribute) {
            _element = element;
            _identifyingAttribute = identifyingAttribute;
        }
        public bool apply(xml.XmlElement childElement) {
            return ((childElement.getName()).Equals((_element).getName())) && (childElement.getAttributeOrNone(_identifyingAttribute)).equals((_element).getAttributeOrNone(_identifyingAttribute));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class EmbeddedStyleMap__Anonymous_2 : Mammoth.Couscous.java.util.function.Predicate<xml.XmlNode> {
        internal xml.XmlElement _element;
        internal string _identifyingAttribute;
        internal EmbeddedStyleMap__Anonymous_2(xml.XmlElement element, string identifyingAttribute) {
            _element = element;
            _identifyingAttribute = identifyingAttribute;
        }
        public bool test(xml.XmlNode child) {
            return ((util.Casts.tryCast<xml.XmlElement>(typeof(xml.XmlElement), child)).map<bool>(new EmbeddedStyleMap__Anonymous_1(_element, _identifyingAttribute))).orElse(false);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal interface FileReader {
        java.io.InputStream getInputStream(string uri);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class NotesXmlReader {
        internal BodyXmlReader _bodyReader;
        internal string _tagName;
        internal documents.NoteType _noteType;
        internal NotesXmlReader(BodyXmlReader bodyReader, string tagName, documents.NoteType noteType) {
            _bodyReader = bodyReader;
            _tagName = tagName;
            _noteType = noteType;
        }
        public static NotesXmlReader footnote(BodyXmlReader bodyReader) {
            return new NotesXmlReader(bodyReader, "footnote", documents.NoteType._FOOTNOTE);
        }
        public static NotesXmlReader endnote(BodyXmlReader bodyReader) {
            return new NotesXmlReader(bodyReader, "endnote", documents.NoteType._ENDNOTE);
        }
        public results.InternalResult<Mammoth.Couscous.java.util.List<documents.Note>> readElement(xml.XmlElement element) {
            java.lang.Iterable<xml.XmlElement> elements = util.Iterables.lazyFilter<xml.XmlElement>(element.findChildren("w:" + _tagName), new NotesXmlReader__Anonymous_0(this));
            return results.InternalResult.flatMap<xml.XmlElement, documents.Note>(elements, new NotesXmlReader__Anonymous_1(this));
        }
        public bool isNoteElement(xml.XmlElement element) {
            return ((element.getAttributeOrNone("w:type")).map<bool>(new NotesXmlReader__Anonymous_2(this))).orElse(true);
        }
        public bool isSeparatorType(string type) {
            return (type.Equals("continuationSeparator")) || (type.Equals("separator"));
        }
        public results.InternalResult<documents.Note> readNoteElement(xml.XmlElement element) {
            return (((_bodyReader).readElements(element.getChildren())).toResult()).map<documents.Note>(new NotesXmlReader__Anonymous_3(this, element));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class NotesXmlReader__Anonymous_0 : Mammoth.Couscous.java.util.function.Predicate<xml.XmlElement> {
        internal NotesXmlReader _this_org__zwobble__mammoth__internal__docx__NotesXmlReader;
        internal NotesXmlReader__Anonymous_0(NotesXmlReader this_org__zwobble__mammoth__internal__docx__NotesXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__NotesXmlReader = this_org__zwobble__mammoth__internal__docx__NotesXmlReader;
        }
        public bool test(xml.XmlElement arg0) {
            return (_this_org__zwobble__mammoth__internal__docx__NotesXmlReader).isNoteElement(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class NotesXmlReader__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, results.InternalResult<documents.Note>> {
        internal NotesXmlReader _this_org__zwobble__mammoth__internal__docx__NotesXmlReader;
        internal NotesXmlReader__Anonymous_1(NotesXmlReader this_org__zwobble__mammoth__internal__docx__NotesXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__NotesXmlReader = this_org__zwobble__mammoth__internal__docx__NotesXmlReader;
        }
        public results.InternalResult<documents.Note> apply(xml.XmlElement arg0) {
            return (_this_org__zwobble__mammoth__internal__docx__NotesXmlReader).readNoteElement(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class NotesXmlReader__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<string, bool> {
        internal NotesXmlReader _this_org__zwobble__mammoth__internal__docx__NotesXmlReader;
        internal NotesXmlReader__Anonymous_2(NotesXmlReader this_org__zwobble__mammoth__internal__docx__NotesXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__NotesXmlReader = this_org__zwobble__mammoth__internal__docx__NotesXmlReader;
        }
        public bool apply(string type) {
            return !(_this_org__zwobble__mammoth__internal__docx__NotesXmlReader).isSeparatorType(type);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class NotesXmlReader__Anonymous_3 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.Note> {
        internal NotesXmlReader _this_org__zwobble__mammoth__internal__docx__NotesXmlReader;
        internal xml.XmlElement _element;
        internal NotesXmlReader__Anonymous_3(NotesXmlReader this_org__zwobble__mammoth__internal__docx__NotesXmlReader, xml.XmlElement element) {
            _this_org__zwobble__mammoth__internal__docx__NotesXmlReader = this_org__zwobble__mammoth__internal__docx__NotesXmlReader;
            _element = element;
        }
        public documents.Note apply(Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            return new documents.Note((_this_org__zwobble__mammoth__internal__docx__NotesXmlReader)._noteType, (_element).getAttribute("w:id"), children);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class Numbering {
        internal static Numbering _EMPTY;
        internal Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> _numbering;
        static Numbering() {
            _EMPTY = new Numbering(util.Maps.map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>>());
        }
        internal Numbering(Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> numbering) {
            _numbering = numbering;
        }
        public Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> findLevel(string numId, string level) {
            return (util.Maps.lookup<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>>(_numbering, numId)).flatMap<documents.NumberingLevel>(new Numbering__Anonymous_0(level));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class Numbering__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>, Mammoth.Couscous.java.util.Optional<documents.NumberingLevel>> {
        internal string _level;
        internal Numbering__Anonymous_0(string level) {
            _level = level;
        }
        public Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> apply(Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel> levels) {
            return util.Maps.lookup<string, documents.NumberingLevel>(levels, _level);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class NumberingXml {
        public static Numbering readNumberingXmlElement(xml.XmlElement element) {
            Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> abstractNums = readAbstractNums(element.findChildren("w:abstractNum"));
            return new Numbering(readNums(element.findChildren("w:num"), abstractNums));
        }
        public static Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> readAbstractNums(xml.XmlElementList children) {
            return util.Maps.toMap<xml.XmlElement, string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>>(children, new NumberingXml__Anonymous_0());
        }
        public static Mammoth.Couscous.java.util.Map__Entry<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> readAbstractNum(xml.XmlElement element) {
            string abstractNumId = element.getAttribute("w:abstractNumId");
            return util.Maps.entry<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>>(abstractNumId, readAbstractNumLevels(element));
        }
        public static Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel> readAbstractNumLevels(xml.XmlElement element) {
            return util.Maps.toMap<xml.XmlElement, string, documents.NumberingLevel>(element.findChildren("w:lvl"), new NumberingXml__Anonymous_1());
        }
        public static Mammoth.Couscous.java.util.Map__Entry<string, documents.NumberingLevel> readAbstractNumLevel(xml.XmlElement element) {
            string levelIndex = element.getAttribute("w:ilvl");
            Mammoth.Couscous.java.util.Optional<string> numFmt = (element.findChildOrEmpty("w:numFmt")).getAttributeOrNone("w:val");
            bool isOrdered = !numFmt.equals(java.util.Optional.of<string>("bullet"));
            return util.Maps.entry<string, documents.NumberingLevel>(levelIndex, new documents.NumberingLevel(levelIndex, isOrdered));
        }
        public static Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> readNums(xml.XmlElementList numElements, Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> abstractNums) {
            return util.Maps.toMap<xml.XmlElement, string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>>(numElements, new NumberingXml__Anonymous_2(abstractNums));
        }
        public static Mammoth.Couscous.java.util.Map__Entry<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> readNum(xml.XmlElement numElement, Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> abstractNums) {
            string numId = numElement.getAttribute("w:numId");
            string abstractNumId = ((numElement.findChild("w:abstractNumId")).get()).getAttribute("w:val");
            return util.Maps.entry<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>>(numId, (util.Maps.lookup<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>>(abstractNums, abstractNumId)).get());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class NumberingXml__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Mammoth.Couscous.java.util.Map__Entry<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>>> {
        public Mammoth.Couscous.java.util.Map__Entry<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> apply(xml.XmlElement arg0) {
            return NumberingXml.readAbstractNum(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class NumberingXml__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Mammoth.Couscous.java.util.Map__Entry<string, documents.NumberingLevel>> {
        public Mammoth.Couscous.java.util.Map__Entry<string, documents.NumberingLevel> apply(xml.XmlElement arg0) {
            return NumberingXml.readAbstractNumLevel(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class NumberingXml__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Mammoth.Couscous.java.util.Map__Entry<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>>> {
        internal Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> _abstractNums;
        internal NumberingXml__Anonymous_2(Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> abstractNums) {
            _abstractNums = abstractNums;
        }
        public Mammoth.Couscous.java.util.Map__Entry<string, Mammoth.Couscous.java.util.Map<string, documents.NumberingLevel>> apply(xml.XmlElement numElement) {
            return NumberingXml.readNum(numElement, _abstractNums);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class OfficeXml {
        internal static xml.NamespacePrefixes _XML_NAMESPACES;
        static OfficeXml() {
            _XML_NAMESPACES = (((((((((((xml.NamespacePrefixes.builder()).put("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main")).put("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing")).put("a", "http://schemas.openxmlformats.org/drawingml/2006/main")).put("pic", "http://schemas.openxmlformats.org/drawingml/2006/picture")).put("content-types", "http://schemas.openxmlformats.org/package/2006/content-types")).put("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships")).put("relationships", "http://schemas.openxmlformats.org/package/2006/relationships")).put("v", "urn:schemas-microsoft-com:vml")).put("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006")).put("office-word", "urn:schemas-microsoft-com:office:word")).build();
        }
        public static xml.XmlElement parseXml(java.io.InputStream inputStream) {
            xml.parsing.XmlParser parser = new xml.parsing.XmlParser(_XML_NAMESPACES);
            return (xml.XmlElement) (collapseAlternateContent(parser.parseStream(inputStream))).get(0);
        }
        public static Mammoth.Couscous.java.util.List<xml.XmlNode> collapseAlternateContent(xml.XmlNode node) {
            return node.accept<Mammoth.Couscous.java.util.List<xml.XmlNode>>(new OfficeXml__Anonymous_1());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class OfficeXml__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<xml.XmlNode, java.lang.Iterable<xml.XmlNode>> {
        public java.lang.Iterable<xml.XmlNode> apply(xml.XmlNode arg0) {
            return OfficeXml.collapseAlternateContent(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class OfficeXml__Anonymous_1 : xml.XmlNodeVisitor<Mammoth.Couscous.java.util.List<xml.XmlNode>> {
        public Mammoth.Couscous.java.util.List<xml.XmlNode> visit(xml.XmlElement element) {
            if ((element.getName()).Equals("mc:AlternateContent")) {
                return (element.findChildOrEmpty("mc:Fallback")).getChildren();
            } else {
                xml.XmlElement collapsedElement = new xml.XmlElement(element.getName(), element.getAttributes(), util.Lists.eagerFlatMap<xml.XmlNode, xml.XmlNode>(element.getChildren(), new OfficeXml__Anonymous_0()));
                return util.Lists.list<xml.XmlNode>(collapsedElement);
            }
        }
        public Mammoth.Couscous.java.util.List<xml.XmlNode> visit(xml.XmlTextNode textNode) {
            return util.Lists.list<xml.XmlNode>(textNode);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class PathRelativeFileReader : FileReader {
        internal Mammoth.Couscous.java.util.Optional<java.nio.file.Path> _path;
        internal PathRelativeFileReader(Mammoth.Couscous.java.util.Optional<java.nio.file.Path> path) {
            _path = path;
        }
        public java.io.InputStream getInputStream(string uri) {
            try {
                Mammoth.Couscous.java.util.Optional<java.net.URI> absoluteUri = asAbsoluteUri(uri);
                if (absoluteUri.isPresent()) {
                    return open(absoluteUri.get());
                } else if ((_path).isPresent()) {
                    return open((((_path).get()).toUri()).resolve(uri));
                } else {
                    throw new java.io.IOException("path of document is unknown, but is required for relative URI");
                }
            } catch (java.io.IOException exception) {
                throw new java.io.IOException((("could not open external image '" + uri) + "': ") + exception.getMessage());
            }
        }
        public static java.io.InputStream open(java.net.URI uri) {
            return (uri.toURL()).openStream();
        }
        public static Mammoth.Couscous.java.util.Optional<java.net.URI> asAbsoluteUri(string uriString) {
            try {
                java.net.URI uri = new java.net.URI(uriString);
                return uri.isAbsolute() ? java.util.Optional.of<java.net.URI>(uri) : java.util.Optional.empty<java.net.URI>();
            } catch (java.net.URISyntaxException) {
                return java.util.Optional.empty<java.net.URI>();
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class ReadResult {
        internal static ReadResult _EMPTY_SUCCESS;
        internal Mammoth.Couscous.java.util.List<documents.DocumentElement> _elements;
        internal Mammoth.Couscous.java.util.List<documents.DocumentElement> _extra;
        internal java.lang.Iterable<string> _warnings;
        static ReadResult() {
            _EMPTY_SUCCESS = success(util.Lists.list<documents.DocumentElement>());
        }
        internal ReadResult(Mammoth.Couscous.java.util.List<documents.DocumentElement> elements, Mammoth.Couscous.java.util.List<documents.DocumentElement> extra, java.lang.Iterable<string> warnings) {
            _elements = elements;
            _extra = extra;
            _warnings = warnings;
        }
        public static ReadResult flatMap<T>(java.lang.Iterable<T> iterable, Mammoth.Couscous.java.util.function.Function<T, ReadResult> function) {
            Mammoth.Couscous.java.util.List<ReadResult> results = util.Lists.eagerMap<T, ReadResult>(iterable, function);
            return new ReadResult(util.Lists.eagerFlatMap<ReadResult, documents.DocumentElement>(results, new ReadResult__Anonymous_0()), util.Lists.eagerFlatMap<ReadResult, documents.DocumentElement>(results, new ReadResult__Anonymous_1()), util.Iterables.lazyFlatMap<ReadResult, string>(results, new ReadResult__Anonymous_2()));
        }
        public static ReadResult map<T>(results.InternalResult<T> first, ReadResult second, Mammoth.Couscous.java.util.function.BiFunction<T, Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.DocumentElement> function) {
            return new ReadResult(util.Lists.list<documents.DocumentElement>(function.apply(first.getValue(), second._elements)), second._extra, util.Iterables.lazyConcat<string>(first.getWarnings(), second._warnings));
        }
        public static ReadResult success(documents.DocumentElement element) {
            return success(util.Lists.list<documents.DocumentElement>(element));
        }
        public static ReadResult success(Mammoth.Couscous.java.util.List<documents.DocumentElement> elements) {
            return new ReadResult(elements, util.Lists.list<documents.DocumentElement>(), util.Lists.list<string>());
        }
        public static ReadResult emptyWithWarning(string warning) {
            return withWarning(util.Lists.list<documents.DocumentElement>(), warning);
        }
        public static ReadResult withWarning(documents.DocumentElement element, string warning) {
            return withWarning(util.Lists.list<documents.DocumentElement>(element), warning);
        }
        public static ReadResult withWarning(Mammoth.Couscous.java.util.List<documents.DocumentElement> elements, string warning) {
            return new ReadResult(elements, util.Lists.list<documents.DocumentElement>(), util.Lists.list<string>(warning));
        }
        public ReadResult map(Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.DocumentElement> function) {
            return new ReadResult(util.Lists.list<documents.DocumentElement>(function.apply(_elements)), _extra, _warnings);
        }
        public ReadResult flatMap(Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, ReadResult> function) {
            ReadResult result = function.apply(_elements);
            return new ReadResult(result._elements, util.Lists.eagerConcat<documents.DocumentElement>(_extra, result._extra), util.Iterables.lazyConcat<string>(_warnings, result._warnings));
        }
        public ReadResult toExtra() {
            return new ReadResult(util.Lists.list<documents.DocumentElement>(), util.Lists.eagerConcat<documents.DocumentElement>(_extra, _elements), _warnings);
        }
        public ReadResult appendExtra() {
            return new ReadResult(util.Lists.eagerConcat<documents.DocumentElement>(_elements, _extra), util.Lists.list<documents.DocumentElement>(), _warnings);
        }
        public results.InternalResult<Mammoth.Couscous.java.util.List<documents.DocumentElement>> toResult() {
            return new results.InternalResult<Mammoth.Couscous.java.util.List<documents.DocumentElement>>(_elements, _warnings);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class ReadResult__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<ReadResult, java.lang.Iterable<documents.DocumentElement>> {
        public java.lang.Iterable<documents.DocumentElement> apply(ReadResult result) {
            return result._elements;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class ReadResult__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<ReadResult, java.lang.Iterable<documents.DocumentElement>> {
        public java.lang.Iterable<documents.DocumentElement> apply(ReadResult result) {
            return result._extra;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class ReadResult__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<ReadResult, java.lang.Iterable<string>> {
        public java.lang.Iterable<string> apply(ReadResult result) {
            return result._warnings;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class Relationship {
        internal string _relationshipId;
        internal string _target;
        internal string _type;
        internal Relationship(string relationshipId, string target, string type) {
            _relationshipId = relationshipId;
            _target = target;
            _type = type;
        }
        public string getRelationshipId() {
            return _relationshipId;
        }
        public string getTarget() {
            return _target;
        }
        public string getType() {
            return _type;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class Relationships {
        internal static Relationships _EMPTY;
        internal Mammoth.Couscous.java.util.Map<string, string> _targetsByRelationshipId;
        internal Mammoth.Couscous.java.util.Map<string, Mammoth.Couscous.java.util.List<string>> _targetsByType;
        static Relationships() {
            _EMPTY = new Relationships(util.Lists.list<Relationship>());
        }
        internal Relationships(Mammoth.Couscous.java.util.List<Relationship> relationships) {
            _targetsByRelationshipId = util.Maps.toMap<Relationship, string, string>(relationships, new Relationships__Anonymous_0());
            _targetsByType = util.Maps.toMultiMap<Relationship, string, string>(relationships, new Relationships__Anonymous_1());
        }
        public string findTargetByRelationshipId(string relationshipId) {
            return (util.Maps.lookup<string, string>(_targetsByRelationshipId, relationshipId)).orElseThrow<java.lang.RuntimeException>(new Relationships__Anonymous_2(relationshipId));
        }
        public Mammoth.Couscous.java.util.List<string> findTargetsByType(string type) {
            return (util.Maps.lookup<string, Mammoth.Couscous.java.util.List<string>>(_targetsByType, type)).orElse(util.Lists.list<string>());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class Relationships__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<Relationship, Mammoth.Couscous.java.util.Map__Entry<string, string>> {
        public Mammoth.Couscous.java.util.Map__Entry<string, string> apply(Relationship relationship) {
            return util.Maps.entry<string, string>(relationship.getRelationshipId(), relationship.getTarget());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class Relationships__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<Relationship, Mammoth.Couscous.java.util.Map__Entry<string, string>> {
        public Mammoth.Couscous.java.util.Map__Entry<string, string> apply(Relationship relationship) {
            return util.Maps.entry<string, string>(relationship.getType(), relationship.getTarget());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class Relationships__Anonymous_2 : Mammoth.Couscous.java.util.function.Supplier<java.lang.RuntimeException> {
        internal string _relationshipId;
        internal Relationships__Anonymous_2(string relationshipId) {
            _relationshipId = relationshipId;
        }
        public java.lang.RuntimeException get() {
            return new java.lang.RuntimeException(("Could not find relationship '" + _relationshipId) + "'");
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class RelationshipsXml {
        public static Relationships readRelationshipsXmlElement(xml.XmlElement element) {
            return new Relationships(util.Lists.eagerMap<xml.XmlElement, Relationship>(element.findChildren("relationships:Relationship"), new RelationshipsXml__Anonymous_0()));
        }
        public static Relationship readRelationship(xml.XmlElement element) {
            string relationshipId = element.getAttribute("Id");
            string target = element.getAttribute("Target");
            string type = element.getAttribute("Type");
            return new Relationship(relationshipId, target, type);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class RelationshipsXml__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Relationship> {
        public Relationship apply(xml.XmlElement arg0) {
            return RelationshipsXml.readRelationship(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader {
        internal static Mammoth.Couscous.java.util.Set<string> _IMAGE_TYPES_SUPPORTED_BY_BROWSERS;
        internal Styles _styles;
        internal Numbering _numbering;
        internal Relationships _relationships;
        internal ContentTypes _contentTypes;
        internal archives.Archive _file;
        internal FileReader _fileReader;
        internal java.lang.StringBuilder _currentInstrText;
        internal Mammoth.Couscous.java.util.Queue<StatefulBodyXmlReader__ComplexField> _complexFieldStack;
        static StatefulBodyXmlReader() {
            _IMAGE_TYPES_SUPPORTED_BY_BROWSERS = util.Sets.set<string>(new string[] {"image/png", "image/gif", "image/jpeg", "image/svg+xml", "image/tiff"});
        }
        internal StatefulBodyXmlReader(Styles styles, Numbering numbering, Relationships relationships, ContentTypes contentTypes, archives.Archive file, FileReader fileReader) {
            _styles = styles;
            _numbering = numbering;
            _relationships = relationships;
            _contentTypes = contentTypes;
            _file = file;
            _fileReader = fileReader;
            _currentInstrText = new java.lang.StringBuilder();
            _complexFieldStack = util.Queues.stack<StatefulBodyXmlReader__ComplexField>();
        }
        public ReadResult readElement(xml.XmlElement element) {
            switch (element.getName()) {
                case "w:t":
                    return ReadResult.success(new documents.Text(element.innerText()));
                case "w:r":
                    return readRun(element);
                case "w:p":
                    return readParagraph(element);
                case "w:fldChar":
                    return readFieldChar(element);
                case "w:instrText":
                    return readInstrText(element);
                case "w:tab":
                    return ReadResult.success(documents.Tab._TAB);
                case "w:noBreakHyphen":
                    return ReadResult.success(new documents.Text("‑"));
                case "w:br":
                    return readBreak(element);
                case "w:tbl":
                    return readTable(element);
                case "w:tr":
                    return readTableRow(element);
                case "w:tc":
                    return readTableCell(element);
                case "w:hyperlink":
                    return readHyperlink(element);
                case "w:bookmarkStart":
                    return readBookmark(element);
                case "w:footnoteReference":
                    return readNoteReference(documents.NoteType._FOOTNOTE, element);
                case "w:endnoteReference":
                    return readNoteReference(documents.NoteType._ENDNOTE, element);
                case "w:commentReference":
                    return readCommentReference(element);
                case "w:pict":
                    return readPict(element);
                case "v:imagedata":
                    return readImagedata(element);
                case "wp:inline":
                case "wp:anchor":
                    return readInline(element);
                case "w:sdt":
                    return readSdt(element);
                case "w:ins":
                case "w:object":
                case "w:smartTag":
                case "w:drawing":
                case "v:group":
                case "v:roundrect":
                case "v:shape":
                case "v:textbox":
                case "w:txbxContent":
                    return readElements(element.getChildren());
                case "office-word:wrap":
                case "v:shadow":
                case "v:shapetype":
                case "w:bookmarkEnd":
                case "w:sectPr":
                case "w:proofErr":
                case "w:lastRenderedPageBreak":
                case "w:commentRangeStart":
                case "w:commentRangeEnd":
                case "w:del":
                case "w:footnoteRef":
                case "w:endnoteRef":
                case "w:annotationRef":
                case "w:pPr":
                case "w:rPr":
                case "w:tblPr":
                case "w:tblGrid":
                case "w:trPr":
                case "w:tcPr":
                    return ReadResult._EMPTY_SUCCESS;
                default:
                    string warning = "An unrecognised element was ignored: " + element.getName();
                    return ReadResult.emptyWithWarning(warning);
            }
        }
        public ReadResult readRun(xml.XmlElement element) {
            xml.XmlElementLike properties = element.findChildOrEmpty("w:rPr");
            return ReadResult.map<Mammoth.Couscous.java.util.Optional<documents.Style>>(readRunStyle(properties), readElements(element.getChildren()), new StatefulBodyXmlReader__Anonymous_0(this, properties));
        }
        public Mammoth.Couscous.java.util.Optional<string> currentHyperlinkHref() {
            return (util.Iterables.tryGetLast<StatefulBodyXmlReader__HyperlinkComplexField>(util.Iterables.lazyFilter<StatefulBodyXmlReader__ComplexField, StatefulBodyXmlReader__HyperlinkComplexField>(_complexFieldStack, typeof(StatefulBodyXmlReader__HyperlinkComplexField)))).map<string>(new StatefulBodyXmlReader__Anonymous_1());
        }
        public bool isBold(xml.XmlElementLike properties) {
            return readBooleanElement(properties, "w:b");
        }
        public bool isItalic(xml.XmlElementLike properties) {
            return readBooleanElement(properties, "w:i");
        }
        public bool isUnderline(xml.XmlElementLike properties) {
            return readBooleanElement(properties, "w:u");
        }
        public bool isStrikethrough(xml.XmlElementLike properties) {
            return readBooleanElement(properties, "w:strike");
        }
        public bool isSmallCaps(xml.XmlElementLike properties) {
            return readBooleanElement(properties, "w:smallCaps");
        }
        public bool readBooleanElement(xml.XmlElementLike properties, string tagName) {
            return ((properties.findChild(tagName)).map<bool>(new StatefulBodyXmlReader__Anonymous_3())).orElse(false);
        }
        public documents.VerticalAlignment readVerticalAlignment(xml.XmlElementLike properties) {
            string verticalAlignment = (readVal(properties, "w:vertAlign")).orElse("");
            switch (verticalAlignment) {
                case "superscript":
                    return documents.VerticalAlignment._SUPERSCRIPT;
                case "subscript":
                    return documents.VerticalAlignment._SUBSCRIPT;
                default:
                    return documents.VerticalAlignment._BASELINE;
            }
        }
        public results.InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>> readRunStyle(xml.XmlElementLike properties) {
            return readStyle(properties, "w:rStyle", "Run", new StatefulBodyXmlReader__Anonymous_4(this));
        }
        public ReadResult readElements(java.lang.Iterable<xml.XmlNode> nodes) {
            return ReadResult.flatMap<xml.XmlElement>(util.Iterables.lazyFilter<xml.XmlNode, xml.XmlElement>(nodes, typeof(xml.XmlElement)), new StatefulBodyXmlReader__Anonymous_5(this));
        }
        public ReadResult readParagraph(xml.XmlElement element) {
            xml.XmlElementLike properties = element.findChildOrEmpty("w:pPr");
            Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> numbering = readNumbering(properties);
            documents.ParagraphIndent indent = readParagraphIndent(properties);
            return (ReadResult.map<Mammoth.Couscous.java.util.Optional<documents.Style>>(readParagraphStyle(properties), readElements(element.getChildren()), new StatefulBodyXmlReader__Anonymous_6(numbering, indent))).appendExtra();
        }
        public ReadResult readFieldChar(xml.XmlElement element) {
            string type = (element.getAttributeOrNone("w:fldCharType")).orElse("");
            if (type.Equals("begin")) {
                (_complexFieldStack).add(StatefulBodyXmlReader__ComplexField_static._UNKNOWN);
                (_currentInstrText).setLength(0);
            } else if (type.Equals("end")) {
                (_complexFieldStack).remove();
            } else if (type.Equals("separate")) {
                string instrText = (_currentInstrText).toString();
                StatefulBodyXmlReader__ComplexField complexField = ((parseHyperlinkFieldCode(instrText)).map<StatefulBodyXmlReader__ComplexField>(new StatefulBodyXmlReader__Anonymous_7())).orElse(StatefulBodyXmlReader__ComplexField_static._UNKNOWN);
                (_complexFieldStack).remove();
                (_complexFieldStack).add(complexField);
            }
            return ReadResult._EMPTY_SUCCESS;
        }
        public ReadResult readInstrText(xml.XmlElement element) {
            (_currentInstrText).append(element.innerText());
            return ReadResult._EMPTY_SUCCESS;
        }
        public Mammoth.Couscous.java.util.Optional<string> parseHyperlinkFieldCode(string instrText) {
            Mammoth.Couscous.java.util.regex.Pattern pattern = java.util.regex.Pattern.compile("\\s*HYPERLINK \"(.*)\"");
            Mammoth.Couscous.java.util.regex.Matcher matcher = pattern.matcher(instrText);
            if (matcher.lookingAt()) {
                return java.util.Optional.of<string>(matcher.group(1));
            } else {
                return java.util.Optional.empty<string>();
            }
        }
        public results.InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>> readParagraphStyle(xml.XmlElementLike properties) {
            return readStyle(properties, "w:pStyle", "Paragraph", new StatefulBodyXmlReader__Anonymous_8(this));
        }
        public results.InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>> readStyle(xml.XmlElementLike properties, string styleTagName, string styleType, Mammoth.Couscous.java.util.function.Function<string, Mammoth.Couscous.java.util.Optional<documents.Style>> findStyleById) {
            return ((readVal(properties, styleTagName)).map<results.InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>>>(new StatefulBodyXmlReader__Anonymous_9(this, styleType, findStyleById))).orElse(results.InternalResult.empty());
        }
        public results.InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>> findStyleById(string styleType, string styleId, Mammoth.Couscous.java.util.function.Function<string, Mammoth.Couscous.java.util.Optional<documents.Style>> findStyleById) {
            Mammoth.Couscous.java.util.Optional<documents.Style> style = findStyleById.apply(styleId);
            if (style.isPresent()) {
                return results.InternalResult.success<Mammoth.Couscous.java.util.Optional<documents.Style>>(style);
            } else {
                return new results.InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>>(java.util.Optional.of<documents.Style>(new documents.Style(styleId, java.util.Optional.empty<string>())), util.Lists.list<string>(((styleType + " style with ID ") + styleId) + " was referenced but not defined in the document"));
            }
        }
        public Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> readNumbering(xml.XmlElementLike properties) {
            xml.XmlElementLike numberingProperties = properties.findChildOrEmpty("w:numPr");
            return util.Optionals.flatMap<string, string, documents.NumberingLevel>(readVal(numberingProperties, "w:numId"), readVal(numberingProperties, "w:ilvl"), new StatefulBodyXmlReader__Anonymous_10(this));
        }
        public documents.ParagraphIndent readParagraphIndent(xml.XmlElementLike properties) {
            xml.XmlElementLike indent = properties.findChildOrEmpty("w:ind");
            return new documents.ParagraphIndent(util.Optionals.first<string>(indent.getAttributeOrNone("w:start"), indent.getAttributeOrNone("w:left")), util.Optionals.first<string>(indent.getAttributeOrNone("w:end"), indent.getAttributeOrNone("w:right")), indent.getAttributeOrNone("w:firstLine"), indent.getAttributeOrNone("w:hanging"));
        }
        public ReadResult readBreak(xml.XmlElement element) {
            string breakType = (element.getAttributeOrNone("w:type")).orElse("textWrapping");
            switch (breakType) {
                case "textWrapping":
                    return ReadResult.success(documents.Break._LINE_BREAK);
                case "page":
                    return ReadResult.success(documents.Break._PAGE_BREAK);
                case "column":
                    return ReadResult.success(documents.Break._COLUMN_BREAK);
                default:
                    return ReadResult.emptyWithWarning("Unsupported break type: " + breakType);
            }
        }
        public ReadResult readTable(xml.XmlElement element) {
            xml.XmlElementLike properties = element.findChildOrEmpty("w:tblPr");
            return ReadResult.map<Mammoth.Couscous.java.util.Optional<documents.Style>>(readTableStyle(properties), (readElements(element.getChildren())).flatMap(new StatefulBodyXmlReader__Anonymous_11(this)), new StatefulBodyXmlReader__Anonymous_12());
        }
        public results.InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>> readTableStyle(xml.XmlElementLike properties) {
            return readStyle(properties, "w:tblStyle", "Table", new StatefulBodyXmlReader__Anonymous_13(this));
        }
        public ReadResult calculateRowspans(Mammoth.Couscous.java.util.List<documents.DocumentElement> rows) {
            Mammoth.Couscous.java.util.Optional<string> error = checkTableRows(rows);
            if (error.isPresent()) {
                return ReadResult.withWarning(rows, error.get());
            }
            Mammoth.Couscous.java.util.Map<Mammoth.Couscous.java.util.Map__Entry<int, int>, int> rowspans = new Mammoth.Couscous.java.util.HashMap<Mammoth.Couscous.java.util.Map__Entry<int, int>, int>();
            Mammoth.Couscous.java.util.Set<Mammoth.Couscous.java.util.Map__Entry<int, int>> merged = new Mammoth.Couscous.java.util.HashSet<Mammoth.Couscous.java.util.Map__Entry<int, int>>();
            Mammoth.Couscous.java.util.Map<int, Mammoth.Couscous.java.util.Map__Entry<int, int>> lastCellForColumn = new Mammoth.Couscous.java.util.HashMap<int, Mammoth.Couscous.java.util.Map__Entry<int, int>>();
             {
                int rowIndex = 0;
                while (rowIndex < rows.size()) {
                    documents.TableRow row = (documents.TableRow) rows.get(rowIndex);
                    int columnIndex = 0;
                     {
                        int cellIndex = 0;
                        while (cellIndex < (row.getChildren()).size()) {
                            StatefulBodyXmlReader__UnmergedTableCell cell = (StatefulBodyXmlReader__UnmergedTableCell) (row.getChildren()).get(cellIndex);
                            Mammoth.Couscous.java.util.Optional<Mammoth.Couscous.java.util.Map__Entry<int, int>> spanningCell = util.Maps.lookup<int, Mammoth.Couscous.java.util.Map__Entry<int, int>>(lastCellForColumn, columnIndex);
                            Mammoth.Couscous.java.util.Map__Entry<int, int> position = util.Maps.entry<int, int>(rowIndex, cellIndex);
                            if (cell._vmerge && spanningCell.isPresent()) {
                                rowspans.put(spanningCell.get(), (util.Maps.lookup<Mammoth.Couscous.java.util.Map__Entry<int, int>, int>(rowspans, spanningCell.get())).get() + 1);
                                merged.add(position);
                            } else {
                                lastCellForColumn.put(columnIndex, position);
                                rowspans.put(position, 1);
                            }
                            columnIndex = columnIndex + cell._colspan;
                            cellIndex = cellIndex + 1;
                        }
                    }
                    rowIndex = rowIndex + 1;
                }
            }
            return ReadResult.success(util.Lists.eagerMapWithIndex<documents.DocumentElement, documents.DocumentElement>(rows, new StatefulBodyXmlReader__Anonymous_14(merged, rowspans)));
        }
        public Mammoth.Couscous.java.util.Optional<string> checkTableRows(Mammoth.Couscous.java.util.List<documents.DocumentElement> rows) {
             {
                Mammoth.Couscous.java.util.Iterator<documents.DocumentElement> _couscous_desugar_foreach_to_for2 = rows.iterator();
                while (_couscous_desugar_foreach_to_for2.hasNext()) {
                    documents.DocumentElement rowElement = _couscous_desugar_foreach_to_for2.next();
                    Mammoth.Couscous.java.util.Optional<documents.TableRow> row = util.Casts.tryCast<documents.TableRow>(typeof(documents.TableRow), rowElement);
                    if (!row.isPresent()) {
                        return java.util.Optional.of<string>("unexpected non-row element in table, cell merging may be incorrect");
                    } else {
                         {
                            Mammoth.Couscous.java.util.Iterator<documents.DocumentElement> _couscous_desugar_foreach_to_for1 = ((row.get()).getChildren()).iterator();
                            while (_couscous_desugar_foreach_to_for1.hasNext()) {
                                documents.DocumentElement cell = _couscous_desugar_foreach_to_for1.next();
                                if (!(cell is StatefulBodyXmlReader__UnmergedTableCell)) {
                                    return java.util.Optional.of<string>("unexpected non-cell element in table row, cell merging may be incorrect");
                                }
                            }
                        }
                    }
                }
            }
            return java.util.Optional.empty<string>();
        }
        public ReadResult readTableRow(xml.XmlElement element) {
            xml.XmlElementLike properties = element.findChildOrEmpty("w:trPr");
            bool isHeader = properties.hasChild("w:tblHeader");
            return (readElements(element.getChildren())).map(new StatefulBodyXmlReader__Anonymous_15(isHeader));
        }
        public ReadResult readTableCell(xml.XmlElement element) {
            xml.XmlElementLike properties = element.findChildOrEmpty("w:tcPr");
            Mammoth.Couscous.java.util.Optional<string> gridSpan = (properties.findChildOrEmpty("w:gridSpan")).getAttributeOrNone("w:val");
            int colspan = (gridSpan.map<int>(new StatefulBodyXmlReader__Anonymous_16())).orElse(1);
            return (readElements(element.getChildren())).map(new StatefulBodyXmlReader__Anonymous_17(this, properties, colspan));
        }
        public bool readVmerge(xml.XmlElementLike properties) {
            return ((properties.findChild("w:vMerge")).map<bool>(new StatefulBodyXmlReader__Anonymous_19())).orElse(false);
        }
        public ReadResult readHyperlink(xml.XmlElement element) {
            Mammoth.Couscous.java.util.Optional<string> relationshipId = element.getAttributeOrNone("r:id");
            Mammoth.Couscous.java.util.Optional<string> anchor = element.getAttributeOrNone("w:anchor");
            Mammoth.Couscous.java.util.Optional<string> targetFrame = (element.getAttributeOrNone("w:tgtFrame")).filter(new StatefulBodyXmlReader__Anonymous_20());
            ReadResult childrenResult = readElements(element.getChildren());
            if (relationshipId.isPresent()) {
                string targetHref = (_relationships).findTargetByRelationshipId(relationshipId.get());
                string href = (anchor.map<string>(new StatefulBodyXmlReader__Anonymous_21(targetHref, anchor))).orElse(targetHref);
                return childrenResult.map(new StatefulBodyXmlReader__Anonymous_22(href, targetFrame));
            } else if (anchor.isPresent()) {
                return childrenResult.map(new StatefulBodyXmlReader__Anonymous_23(anchor, targetFrame));
            } else {
                return childrenResult;
            }
        }
        public ReadResult readBookmark(xml.XmlElement element) {
            string name = element.getAttribute("w:name");
            if (name.Equals("_GoBack")) {
                return ReadResult._EMPTY_SUCCESS;
            } else {
                return ReadResult.success(new documents.Bookmark(name));
            }
        }
        public ReadResult readNoteReference(documents.NoteType noteType, xml.XmlElement element) {
            string noteId = element.getAttribute("w:id");
            return ReadResult.success(new documents.NoteReference(noteType, noteId));
        }
        public ReadResult readCommentReference(xml.XmlElement element) {
            string commentId = element.getAttribute("w:id");
            return ReadResult.success(new documents.CommentReference(commentId));
        }
        public ReadResult readPict(xml.XmlElement element) {
            return (readElements(element.getChildren())).toExtra();
        }
        public ReadResult readImagedata(xml.XmlElement element) {
            return ((element.getAttributeOrNone("r:id")).map<ReadResult>(new StatefulBodyXmlReader__Anonymous_25(element, this))).orElse(ReadResult.emptyWithWarning("A v:imagedata element without a relationship ID was ignored"));
        }
        public ReadResult readInline(xml.XmlElement element) {
            xml.XmlElementLike properties = element.findChildOrEmpty("wp:docPr");
            Mammoth.Couscous.java.util.Optional<string> altText = util.Optionals.first<string>((properties.getAttributeOrNone("descr")).filter(new StatefulBodyXmlReader__Anonymous_26()), properties.getAttributeOrNone("title"));
            xml.XmlElementList blips = ((((element.findChildren("a:graphic")).findChildren("a:graphicData")).findChildren("pic:pic")).findChildren("pic:blipFill")).findChildren("a:blip");
            return readBlips(blips, altText);
        }
        public ReadResult readBlips(xml.XmlElementList blips, Mammoth.Couscous.java.util.Optional<string> altText) {
            return ReadResult.flatMap<xml.XmlElement>(blips, new StatefulBodyXmlReader__Anonymous_27(this, altText));
        }
        public ReadResult readBlip(xml.XmlElement blip, Mammoth.Couscous.java.util.Optional<string> altText) {
            Mammoth.Couscous.java.util.Optional<string> embedRelationshipId = blip.getAttributeOrNone("r:embed");
            Mammoth.Couscous.java.util.Optional<string> linkRelationshipId = blip.getAttributeOrNone("r:link");
            if (embedRelationshipId.isPresent()) {
                string imagePath = relationshipIdToDocxPath(embedRelationshipId.get());
                return readImage(imagePath, altText, new StatefulBodyXmlReader__Anonymous_28(this, imagePath));
            } else if (linkRelationshipId.isPresent()) {
                string imagePath = (_relationships).findTargetByRelationshipId(linkRelationshipId.get());
                return readImage(imagePath, altText, new StatefulBodyXmlReader__Anonymous_29(this, imagePath));
            } else {
                return ReadResult._EMPTY_SUCCESS;
            }
        }
        public ReadResult readImage(string imagePath, Mammoth.Couscous.java.util.Optional<string> altText, util.InputStreamSupplier open) {
            Mammoth.Couscous.java.util.Optional<string> contentType = (_contentTypes).findContentType(imagePath);
            documents.Image image = new documents.Image(altText, contentType, open);
            string contentTypeString = contentType.orElse("(unknown)");
            if ((_IMAGE_TYPES_SUPPORTED_BY_BROWSERS).contains(contentTypeString)) {
                return ReadResult.success(image);
            } else {
                return ReadResult.withWarning(image, ("Image of type " + contentTypeString) + " is unlikely to display in web browsers");
            }
        }
        public ReadResult readSdt(xml.XmlElement element) {
            return readElements((element.findChildOrEmpty("w:sdtContent")).getChildren());
        }
        public string relationshipIdToDocxPath(string relationshipId) {
            string target = (_relationships).findTargetByRelationshipId(relationshipId);
            return Uris.uriToZipEntryName("word", target);
        }
        public Mammoth.Couscous.java.util.Optional<string> readVal(xml.XmlElementLike element, string name) {
            return (element.findChildOrEmpty(name)).getAttributeOrNone("w:val");
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__ComplexField_static {
        internal static StatefulBodyXmlReader__ComplexField _UNKNOWN;
        static StatefulBodyXmlReader__ComplexField_static() {
            _UNKNOWN = new StatefulBodyXmlReader__Anonymous_30();
        }
        public static StatefulBodyXmlReader__ComplexField hyperlink(string href) {
            return new StatefulBodyXmlReader__HyperlinkComplexField(href);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal interface StatefulBodyXmlReader__ComplexField {
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__HyperlinkComplexField : StatefulBodyXmlReader__ComplexField {
        internal string _href;
        internal StatefulBodyXmlReader__HyperlinkComplexField(string href) {
            _href = href;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__UnmergedTableCell : documents.DocumentElement {
        internal bool _vmerge;
        internal int _colspan;
        internal Mammoth.Couscous.java.util.List<documents.DocumentElement> _children;
        internal StatefulBodyXmlReader__UnmergedTableCell(bool vmerge, int colspan, Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            _vmerge = vmerge;
            _colspan = colspan;
            _children = children;
        }
        public T accept<T, U>(documents.DocumentElementVisitor<T, U> visitor, U context) {
            return visitor.visit(new documents.TableCell(1, _colspan, _children), context);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_0 : Mammoth.Couscous.java.util.function.BiFunction<Mammoth.Couscous.java.util.Optional<documents.Style>, Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.DocumentElement> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal xml.XmlElementLike _properties;
        internal StatefulBodyXmlReader__Anonymous_0(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader, xml.XmlElementLike properties) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
            _properties = properties;
        }
        public documents.DocumentElement apply(Mammoth.Couscous.java.util.Optional<documents.Style> style, Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            Mammoth.Couscous.java.util.Optional<string> hyperlinkHref = (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).currentHyperlinkHref();
            if (hyperlinkHref.isPresent()) {
                children = util.Lists.list<documents.DocumentElement>(documents.Hyperlink.href(hyperlinkHref.get(), java.util.Optional.empty<string>(), children));
            }
            return new documents.Run((_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).isBold(_properties), (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).isItalic(_properties), (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).isUnderline(_properties), (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).isStrikethrough(_properties), (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).isSmallCaps(_properties), (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).readVerticalAlignment(_properties), style, children);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<StatefulBodyXmlReader__HyperlinkComplexField, string> {
        public string apply(StatefulBodyXmlReader__HyperlinkComplexField field) {
            return field._href;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<string, bool> {
        public bool apply(string value) {
            return !(value.Equals("false")) && !(value.Equals("0"));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_3 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, bool> {
        public bool apply(xml.XmlElement child) {
            return ((child.getAttributeOrNone("w:val")).map<bool>(new StatefulBodyXmlReader__Anonymous_2())).orElse(true);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_4 : Mammoth.Couscous.java.util.function.Function<string, Mammoth.Couscous.java.util.Optional<documents.Style>> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal StatefulBodyXmlReader__Anonymous_4(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        }
        public Mammoth.Couscous.java.util.Optional<documents.Style> apply(string arg0) {
            return ((_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader)._styles).findCharacterStyleById(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_5 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, ReadResult> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal StatefulBodyXmlReader__Anonymous_5(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        }
        public ReadResult apply(xml.XmlElement arg0) {
            return (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).readElement(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_6 : Mammoth.Couscous.java.util.function.BiFunction<Mammoth.Couscous.java.util.Optional<documents.Style>, Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.DocumentElement> {
        internal Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> _numbering;
        internal documents.ParagraphIndent _indent;
        internal StatefulBodyXmlReader__Anonymous_6(Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> numbering, documents.ParagraphIndent indent) {
            _numbering = numbering;
            _indent = indent;
        }
        public documents.DocumentElement apply(Mammoth.Couscous.java.util.Optional<documents.Style> style, Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            return new documents.Paragraph(style, _numbering, _indent, children);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_7 : Mammoth.Couscous.java.util.function.Function<string, StatefulBodyXmlReader__ComplexField> {
        public StatefulBodyXmlReader__ComplexField apply(string href) {
            return StatefulBodyXmlReader__ComplexField_static.hyperlink(href);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_8 : Mammoth.Couscous.java.util.function.Function<string, Mammoth.Couscous.java.util.Optional<documents.Style>> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal StatefulBodyXmlReader__Anonymous_8(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        }
        public Mammoth.Couscous.java.util.Optional<documents.Style> apply(string arg0) {
            return ((_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader)._styles).findParagraphStyleById(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_9 : Mammoth.Couscous.java.util.function.Function<string, results.InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>>> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal string _styleType;
        internal Mammoth.Couscous.java.util.function.Function<string, Mammoth.Couscous.java.util.Optional<documents.Style>> _findStyleById;
        internal StatefulBodyXmlReader__Anonymous_9(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader, string styleType, Mammoth.Couscous.java.util.function.Function<string, Mammoth.Couscous.java.util.Optional<documents.Style>> findStyleById) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
            _styleType = styleType;
            _findStyleById = findStyleById;
        }
        public results.InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>> apply(string styleId) {
            return (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).findStyleById(_styleType, styleId, _findStyleById);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_10 : Mammoth.Couscous.java.util.function.BiFunction<string, string, Mammoth.Couscous.java.util.Optional<documents.NumberingLevel>> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal StatefulBodyXmlReader__Anonymous_10(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        }
        public Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> apply(string arg0, string arg1) {
            return ((_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader)._numbering).findLevel(arg0, arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_11 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, ReadResult> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal StatefulBodyXmlReader__Anonymous_11(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        }
        public ReadResult apply(Mammoth.Couscous.java.util.List<documents.DocumentElement> arg0) {
            return (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).calculateRowspans(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_12 : Mammoth.Couscous.java.util.function.BiFunction<Mammoth.Couscous.java.util.Optional<documents.Style>, Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.DocumentElement> {
        public documents.DocumentElement apply(Mammoth.Couscous.java.util.Optional<documents.Style> arg0, Mammoth.Couscous.java.util.List<documents.DocumentElement> arg1) {
            return new documents.Table(arg0, arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_13 : Mammoth.Couscous.java.util.function.Function<string, Mammoth.Couscous.java.util.Optional<documents.Style>> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal StatefulBodyXmlReader__Anonymous_13(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        }
        public Mammoth.Couscous.java.util.Optional<documents.Style> apply(string arg0) {
            return ((_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader)._styles).findTableStyleById(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_14 : Mammoth.Couscous.java.util.function.BiFunction<int, documents.DocumentElement, documents.DocumentElement> {
        internal Mammoth.Couscous.java.util.Set<Mammoth.Couscous.java.util.Map__Entry<int, int>> _merged;
        internal Mammoth.Couscous.java.util.Map<Mammoth.Couscous.java.util.Map__Entry<int, int>, int> _rowspans;
        internal StatefulBodyXmlReader__Anonymous_14(Mammoth.Couscous.java.util.Set<Mammoth.Couscous.java.util.Map__Entry<int, int>> merged, Mammoth.Couscous.java.util.Map<Mammoth.Couscous.java.util.Map__Entry<int, int>, int> rowspans) {
            _merged = merged;
            _rowspans = rowspans;
        }
        public documents.DocumentElement apply(int rowIndex, documents.DocumentElement rowElement) {
            documents.TableRow row = (documents.TableRow) rowElement;
            Mammoth.Couscous.java.util.List<documents.DocumentElement> mergedCells = new Mammoth.Couscous.java.util.ArrayList<documents.DocumentElement>();
             {
                int cellIndex = 0;
                while (cellIndex < (row.getChildren()).size()) {
                    StatefulBodyXmlReader__UnmergedTableCell cell = (StatefulBodyXmlReader__UnmergedTableCell) (row.getChildren()).get(cellIndex);
                    Mammoth.Couscous.java.util.Map__Entry<int, int> position = util.Maps.entry<int, int>(rowIndex, cellIndex);
                    if (!(_merged).contains(position)) {
                        mergedCells.add(new documents.TableCell((util.Maps.lookup<Mammoth.Couscous.java.util.Map__Entry<int, int>, int>(_rowspans, position)).get(), cell._colspan, cell._children));
                    }
                    cellIndex = cellIndex + 1;
                }
            }
            return new documents.TableRow(mergedCells, row.isHeader());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_15 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.DocumentElement> {
        internal bool _isHeader;
        internal StatefulBodyXmlReader__Anonymous_15(bool isHeader) {
            _isHeader = isHeader;
        }
        public documents.DocumentElement apply(Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            return new documents.TableRow(children, _isHeader);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_16 : Mammoth.Couscous.java.util.function.Function<string, int> {
        public int apply(string arg0) {
            return int.Parse(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_17 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.DocumentElement> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal xml.XmlElementLike _properties;
        internal int _colspan;
        internal StatefulBodyXmlReader__Anonymous_17(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader, xml.XmlElementLike properties, int colspan) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
            _properties = properties;
            _colspan = colspan;
        }
        public documents.DocumentElement apply(Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            return new StatefulBodyXmlReader__UnmergedTableCell((_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).readVmerge(_properties), _colspan, children);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_18 : Mammoth.Couscous.java.util.function.Function<string, bool> {
        public bool apply(string val) {
            return val.Equals("continue");
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_19 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, bool> {
        public bool apply(xml.XmlElement element) {
            return ((element.getAttributeOrNone("w:val")).map<bool>(new StatefulBodyXmlReader__Anonymous_18())).orElse(true);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_20 : Mammoth.Couscous.java.util.function.Predicate<string> {
        public bool test(string value) {
            return !value.isEmpty();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_21 : Mammoth.Couscous.java.util.function.Function<string, string> {
        internal string _targetHref;
        internal Mammoth.Couscous.java.util.Optional<string> _anchor;
        internal StatefulBodyXmlReader__Anonymous_21(string targetHref, Mammoth.Couscous.java.util.Optional<string> anchor) {
            _targetHref = targetHref;
            _anchor = anchor;
        }
        public string apply(string fragment) {
            return Uris.replaceFragment(_targetHref, (_anchor).get());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_22 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.DocumentElement> {
        internal string _href;
        internal Mammoth.Couscous.java.util.Optional<string> _targetFrame;
        internal StatefulBodyXmlReader__Anonymous_22(string href, Mammoth.Couscous.java.util.Optional<string> targetFrame) {
            _href = href;
            _targetFrame = targetFrame;
        }
        public documents.DocumentElement apply(Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            return documents.Hyperlink.href(_href, _targetFrame, children);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_23 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.List<documents.DocumentElement>, documents.DocumentElement> {
        internal Mammoth.Couscous.java.util.Optional<string> _anchor;
        internal Mammoth.Couscous.java.util.Optional<string> _targetFrame;
        internal StatefulBodyXmlReader__Anonymous_23(Mammoth.Couscous.java.util.Optional<string> anchor, Mammoth.Couscous.java.util.Optional<string> targetFrame) {
            _anchor = anchor;
            _targetFrame = targetFrame;
        }
        public documents.DocumentElement apply(Mammoth.Couscous.java.util.List<documents.DocumentElement> children) {
            return documents.Hyperlink.anchor((_anchor).get(), _targetFrame, children);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_24 : util.InputStreamSupplier {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal string _imagePath;
        internal StatefulBodyXmlReader__Anonymous_24(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader, string imagePath) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
            _imagePath = imagePath;
        }
        public java.io.InputStream open() {
            return archives.Archives.getInputStream((_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader)._file, _imagePath);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_25 : Mammoth.Couscous.java.util.function.Function<string, ReadResult> {
        internal xml.XmlElement _element;
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal StatefulBodyXmlReader__Anonymous_25(xml.XmlElement element, StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader) {
            _element = element;
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        }
        public ReadResult apply(string relationshipId) {
            Mammoth.Couscous.java.util.Optional<string> title = (_element).getAttributeOrNone("o:title");
            string imagePath = (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).relationshipIdToDocxPath(relationshipId);
            return (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).readImage(imagePath, title, new StatefulBodyXmlReader__Anonymous_24(_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader, imagePath));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_26 : Mammoth.Couscous.java.util.function.Predicate<string> {
        public bool test(string description) {
            return !(description.trim()).isEmpty();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_27 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, ReadResult> {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal Mammoth.Couscous.java.util.Optional<string> _altText;
        internal StatefulBodyXmlReader__Anonymous_27(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader, Mammoth.Couscous.java.util.Optional<string> altText) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
            _altText = altText;
        }
        public ReadResult apply(xml.XmlElement blip) {
            return (_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader).readBlip(blip, _altText);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_28 : util.InputStreamSupplier {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal string _imagePath;
        internal StatefulBodyXmlReader__Anonymous_28(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader, string imagePath) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
            _imagePath = imagePath;
        }
        public java.io.InputStream open() {
            return archives.Archives.getInputStream((_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader)._file, _imagePath);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_29 : util.InputStreamSupplier {
        internal StatefulBodyXmlReader _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
        internal string _imagePath;
        internal StatefulBodyXmlReader__Anonymous_29(StatefulBodyXmlReader this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader, string imagePath) {
            _this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader = this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader;
            _imagePath = imagePath;
        }
        public java.io.InputStream open() {
            return ((_this_org__zwobble__mammoth__internal__docx__StatefulBodyXmlReader)._fileReader).getInputStream(_imagePath);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StatefulBodyXmlReader__Anonymous_30 : StatefulBodyXmlReader__ComplexField {
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class Styles {
        internal static Styles _EMPTY;
        internal Mammoth.Couscous.java.util.Map<string, documents.Style> _paragraphStyles;
        internal Mammoth.Couscous.java.util.Map<string, documents.Style> _characterStyles;
        internal Mammoth.Couscous.java.util.Map<string, documents.Style> _tableStyles;
        static Styles() {
            _EMPTY = new Styles(util.Maps.map<string, documents.Style>(), util.Maps.map<string, documents.Style>(), util.Maps.map<string, documents.Style>());
        }
        internal Styles(Mammoth.Couscous.java.util.Map<string, documents.Style> paragraphStyles, Mammoth.Couscous.java.util.Map<string, documents.Style> characterStyles, Mammoth.Couscous.java.util.Map<string, documents.Style> tableStyles) {
            _paragraphStyles = paragraphStyles;
            _characterStyles = characterStyles;
            _tableStyles = tableStyles;
        }
        public Mammoth.Couscous.java.util.Optional<documents.Style> findParagraphStyleById(string id) {
            return util.Maps.lookup<string, documents.Style>(_paragraphStyles, id);
        }
        public Mammoth.Couscous.java.util.Optional<documents.Style> findCharacterStyleById(string id) {
            return util.Maps.lookup<string, documents.Style>(_characterStyles, id);
        }
        public Mammoth.Couscous.java.util.Optional<documents.Style> findTableStyleById(string id) {
            return util.Maps.lookup<string, documents.Style>(_tableStyles, id);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StylesXml {
        public static Styles readStylesXmlElement(xml.XmlElement element) {
            xml.XmlElementList styleElements = element.findChildren("w:style");
            return new Styles(readStyles(styleElements, "paragraph"), readStyles(styleElements, "character"), readStyles(styleElements, "table"));
        }
        public static Mammoth.Couscous.java.util.Map<string, documents.Style> readStyles(xml.XmlElementList styleElements, string styleType) {
            return util.Maps.toMap<xml.XmlElement, string, documents.Style>(util.Iterables.lazyFilter<xml.XmlElement>(styleElements, new StylesXml__Anonymous_0(styleType)), new StylesXml__Anonymous_1());
        }
        public static Mammoth.Couscous.java.util.Map__Entry<string, documents.Style> readStyle(xml.XmlElement element) {
            string styleId = element.getAttribute("w:styleId");
            Mammoth.Couscous.java.util.Optional<string> styleName = (element.findChildOrEmpty("w:name")).getAttributeOrNone("w:val");
            return util.Maps.entry<string, documents.Style>(styleId, new documents.Style(styleId, styleName));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StylesXml__Anonymous_0 : Mammoth.Couscous.java.util.function.Predicate<xml.XmlElement> {
        internal string _styleType;
        internal StylesXml__Anonymous_0(string styleType) {
            _styleType = styleType;
        }
        public bool test(xml.XmlElement styleElement) {
            return (styleElement.getAttribute("w:type")).Equals(_styleType);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class StylesXml__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<xml.XmlElement, Mammoth.Couscous.java.util.Map__Entry<string, documents.Style>> {
        public Mammoth.Couscous.java.util.Map__Entry<string, documents.Style> apply(xml.XmlElement arg0) {
            return StylesXml.readStyle(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.docx {
    internal class Uris {
        public static string uriToZipEntryName(string @base, string uri) {
            if (uri.startsWith("/")) {
                return uri.Substring(1);
            } else {
                return (@base + "/") + uri;
            }
        }
        public static string replaceFragment(string uri, string fragment) {
            int hashIndex = uri.indexOf("#");
            if (hashIndex != -1) {
                uri = (uri.Substring(0, hashIndex - 0));
            }
            return (uri + "#") + fragment;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class Html {
        internal static HtmlNode _FORCE_WRITE;
        static Html() {
            _FORCE_WRITE = HtmlForceWrite._FORCE_WRITE;
        }
        public static string write(Mammoth.Couscous.java.util.List<HtmlNode> nodes) {
            java.lang.StringBuilder builder = new java.lang.StringBuilder();
            nodes.forEach(new Html__Anonymous_0(builder));
            return builder.toString();
        }
        public static HtmlNode text(string value) {
            return new HtmlTextNode(value);
        }
        public static HtmlNode element(string tagName) {
            return element(tagName, util.Lists.list<HtmlNode>());
        }
        public static HtmlNode element(string tagName, Mammoth.Couscous.java.util.Map<string, string> attributes) {
            return element(tagName, attributes, util.Lists.list<HtmlNode>());
        }
        public static HtmlNode element(string tagName, Mammoth.Couscous.java.util.List<HtmlNode> children) {
            return element(tagName, util.Maps.map<string, string>(), children);
        }
        public static HtmlNode element(string tagName, Mammoth.Couscous.java.util.Map<string, string> attributes, Mammoth.Couscous.java.util.List<HtmlNode> children) {
            return new HtmlElement(new HtmlTag(util.Lists.list<string>(tagName), attributes, false, ""), children);
        }
        public static HtmlNode collapsibleElement(string tagName) {
            return collapsibleElement(util.Lists.list<string>(tagName));
        }
        public static HtmlNode collapsibleElement(Mammoth.Couscous.java.util.List<string> tagNames) {
            return collapsibleElement(tagNames, util.Maps.map<string, string>(), util.Lists.list<HtmlNode>());
        }
        public static HtmlNode collapsibleElement(string tagName, Mammoth.Couscous.java.util.List<HtmlNode> children) {
            return collapsibleElement(tagName, util.Maps.map<string, string>(), children);
        }
        public static HtmlNode collapsibleElement(string tagName, Mammoth.Couscous.java.util.Map<string, string> attributes, Mammoth.Couscous.java.util.List<HtmlNode> children) {
            return collapsibleElement(util.Lists.list<string>(tagName), attributes, children);
        }
        public static HtmlNode collapsibleElement(Mammoth.Couscous.java.util.List<string> tagNames, Mammoth.Couscous.java.util.Map<string, string> attributes, Mammoth.Couscous.java.util.List<HtmlNode> children) {
            return new HtmlElement(new HtmlTag(tagNames, attributes, true, ""), children);
        }
        public static Mammoth.Couscous.java.util.List<HtmlNode> stripEmpty(Mammoth.Couscous.java.util.List<HtmlNode> nodes) {
            return util.Lists.eagerFlatMap<HtmlNode, HtmlNode>(nodes, new Html__Anonymous_1());
        }
        public static Mammoth.Couscous.java.util.List<HtmlNode> stripEmpty(HtmlNode node) {
            return node.accept<Mammoth.Couscous.java.util.List<HtmlNode>>(new Html__Anonymous_2());
        }
        public static Mammoth.Couscous.java.util.List<HtmlNode> collapse(Mammoth.Couscous.java.util.List<HtmlNode> nodes) {
            Mammoth.Couscous.java.util.List<HtmlNode> collapsed = new Mammoth.Couscous.java.util.ArrayList<HtmlNode>();
             {
                Mammoth.Couscous.java.util.Iterator<HtmlNode> _couscous_desugar_foreach_to_for3 = nodes.iterator();
                while (_couscous_desugar_foreach_to_for3.hasNext()) {
                    HtmlNode node = _couscous_desugar_foreach_to_for3.next();
                    collapsingAdd(collapsed, node);
                }
            }
            return collapsed;
        }
        public static void collapsingAdd(Mammoth.Couscous.java.util.List<HtmlNode> collapsed, HtmlNode node) {
            HtmlNode collapsedNode = collapse(node);
            if (!tryCollapse(collapsed, collapsedNode)) {
                collapsed.add(collapsedNode);
            }
        }
        public static HtmlNode collapse(HtmlNode node) {
            return node.accept<HtmlNode>(new Html__Anonymous_3());
        }
        public static bool tryCollapse(Mammoth.Couscous.java.util.List<HtmlNode> collapsed, HtmlNode node) {
            return (util.Optionals.map<HtmlElement, HtmlElement, bool>((util.Lists.tryGetLast<HtmlNode>(collapsed)).flatMap<HtmlElement>(new Html__Anonymous_4()), util.Casts.tryCast<HtmlElement>(typeof(HtmlElement), node), new Html__Anonymous_5())).orElse(false);
        }
        public static bool isMatch(HtmlElement first, HtmlElement second) {
            return (second.getTagNames()).contains(first.getTagName()) && (first.getAttributes()).equals(second.getAttributes());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class Html__Anonymous_0 : Mammoth.Couscous.java.util.function.Consumer<HtmlNode> {
        internal java.lang.StringBuilder _builder;
        internal Html__Anonymous_0(java.lang.StringBuilder builder) {
            _builder = builder;
        }
        public void accept(HtmlNode node) {
            HtmlWriter.write(node, _builder);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class Html__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<HtmlNode, java.lang.Iterable<HtmlNode>> {
        public java.lang.Iterable<HtmlNode> apply(HtmlNode node) {
            return Html.stripEmpty(node);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class Html__Anonymous_2 : HtmlNode__Mapper<Mammoth.Couscous.java.util.List<HtmlNode>> {
        public Mammoth.Couscous.java.util.List<HtmlNode> visit(HtmlElement element) {
            Mammoth.Couscous.java.util.List<HtmlNode> children = Html.stripEmpty(element.getChildren());
            if (children.isEmpty() && !element.isVoid()) {
                return util.Lists.list<HtmlNode>();
            } else {
                return util.Lists.list<HtmlNode>(new HtmlElement(element.getTag(), children));
            }
        }
        public Mammoth.Couscous.java.util.List<HtmlNode> visit(HtmlTextNode node) {
            if ((node.getValue()).isEmpty()) {
                return util.Lists.list<HtmlNode>();
            } else {
                return util.Lists.list<HtmlNode>(node);
            }
        }
        public Mammoth.Couscous.java.util.List<HtmlNode> visit(HtmlForceWrite forceWrite) {
            return util.Lists.list<HtmlNode>(forceWrite);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class Html__Anonymous_3 : HtmlNode__Mapper<HtmlNode> {
        public HtmlNode visit(HtmlElement element) {
            return new HtmlElement(element.getTag(), Html.collapse(element.getChildren()));
        }
        public HtmlNode visit(HtmlTextNode node) {
            return node;
        }
        public HtmlNode visit(HtmlForceWrite forceWrite) {
            return forceWrite;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class Html__Anonymous_4 : Mammoth.Couscous.java.util.function.Function<HtmlNode, Mammoth.Couscous.java.util.Optional<HtmlElement>> {
        public Mammoth.Couscous.java.util.Optional<HtmlElement> apply(HtmlNode last) {
            return util.Casts.tryCast<HtmlElement>(typeof(HtmlElement), last);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class Html__Anonymous_5 : Mammoth.Couscous.java.util.function.BiFunction<HtmlElement, HtmlElement, bool> {
        public bool apply(HtmlElement last, HtmlElement next) {
            if (next.isCollapsible() && Html.isMatch(last, next)) {
                string separator = next.getSeparator();
                if (!separator.isEmpty()) {
                    (last.getChildren()).add(Html.text(separator));
                }
                 {
                    Mammoth.Couscous.java.util.Iterator<HtmlNode> _couscous_desugar_foreach_to_for4 = (next.getChildren()).iterator();
                    while (_couscous_desugar_foreach_to_for4.hasNext()) {
                        HtmlNode child = _couscous_desugar_foreach_to_for4.next();
                        Html.collapsingAdd(last.getChildren(), child);
                    }
                }
                return true;
            } else {
                return false;
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class HtmlElement : HtmlNode {
        internal HtmlTag _tag;
        internal Mammoth.Couscous.java.util.List<HtmlNode> _children;
        internal static Mammoth.Couscous.java.util.Set<string> _VOID_TAG_NAMES;
        static HtmlElement() {
            _VOID_TAG_NAMES = util.Sets.set<string>(new string[] {"img", "br", "hr"});
        }
        internal HtmlElement(HtmlTag tag, Mammoth.Couscous.java.util.List<HtmlNode> children) {
            _tag = tag;
            _children = children;
        }
        public HtmlTag getTag() {
            return _tag;
        }
        public Mammoth.Couscous.java.util.List<string> getTagNames() {
            return (_tag).getTagNames();
        }
        public string getTagName() {
            return (getTagNames()).get(0);
        }
        public Mammoth.Couscous.java.util.Map<string, string> getAttributes() {
            return (_tag).getAttributes();
        }
        public Mammoth.Couscous.java.util.List<HtmlNode> getChildren() {
            return _children;
        }
        public bool isCollapsible() {
            return (_tag).isCollapsible();
        }
        public string getSeparator() {
            return (_tag).getSeparator();
        }
        public bool isVoid() {
            return (_children).isEmpty() && isVoidTag(getTagName());
        }
        public static bool isVoidTag(string tagName) {
            return (_VOID_TAG_NAMES).contains(tagName);
        }
        public void accept(HtmlNode__Visitor visitor) {
            visitor.visit(this);
        }
        public T accept<T>(HtmlNode__Mapper<T> visitor) {
            return visitor.visit(this);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class HtmlForceWrite : HtmlNode {
        internal static HtmlForceWrite _FORCE_WRITE;
        static HtmlForceWrite() {
            _FORCE_WRITE = new HtmlForceWrite();
        }
        public void accept(HtmlNode__Visitor visitor) {
            visitor.visit(this);
        }
        public T accept<T>(HtmlNode__Mapper<T> visitor) {
            return visitor.visit(this);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal interface HtmlNode {
        void accept(HtmlNode__Visitor visitor);
        T accept<T>(HtmlNode__Mapper<T> visitor);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal interface HtmlNode__Visitor {
        void visit(HtmlElement element);
        void visit(HtmlTextNode node);
        void visit(HtmlForceWrite forceWrite);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal interface HtmlNode__Mapper<T> {
        T visit(HtmlElement element);
        T visit(HtmlTextNode node);
        T visit(HtmlForceWrite forceWrite);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class HtmlTag {
        internal Mammoth.Couscous.java.util.List<string> _tagNames;
        internal Mammoth.Couscous.java.util.Map<string, string> _attributes;
        internal bool _isCollapsible;
        internal string _separator;
        internal HtmlTag(Mammoth.Couscous.java.util.List<string> tagNames, Mammoth.Couscous.java.util.Map<string, string> attributes, bool isCollapsible, string separator) {
            _tagNames = tagNames;
            _attributes = attributes;
            _isCollapsible = isCollapsible;
            _separator = separator;
        }
        public Mammoth.Couscous.java.util.List<string> getTagNames() {
            return _tagNames;
        }
        public Mammoth.Couscous.java.util.Map<string, string> getAttributes() {
            return _attributes;
        }
        public bool isCollapsible() {
            return _isCollapsible;
        }
        public string getSeparator() {
            return _separator;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class HtmlTextNode : HtmlNode {
        internal string _value;
        internal HtmlTextNode(string value) {
            _value = value;
        }
        public string getValue() {
            return _value;
        }
        public void accept(HtmlNode__Visitor visitor) {
            visitor.visit(this);
        }
        public T accept<T>(HtmlNode__Mapper<T> visitor) {
            return visitor.visit(this);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class HtmlWriter {
        public static void write(HtmlNode node, java.lang.StringBuilder builder) {
            node.accept(new HtmlWriter__Anonymous_1(builder));
        }
        public static void generateAttributes(Mammoth.Couscous.java.util.Map<string, string> attributes, java.lang.StringBuilder builder) {
             {
                Mammoth.Couscous.java.util.Iterator<Mammoth.Couscous.java.util.Map__Entry<string, string>> _couscous_desugar_foreach_to_for5 = (util.Lists.orderedBy<Mammoth.Couscous.java.util.Map__Entry<string, string>, string>(attributes.entrySet(), new HtmlWriter__Anonymous_2())).iterator();
                while (_couscous_desugar_foreach_to_for5.hasNext()) {
                    Mammoth.Couscous.java.util.Map__Entry<string, string> attribute = _couscous_desugar_foreach_to_for5.next();
                    ((((builder.append(" ")).append(attribute.getKey())).append("=\"")).append(escapeAttributeValue(attribute.getValue()))).append("\"");
                }
            }
        }
        public static string escapeText(string text) {
            return ((text.replace("&", "&amp;")).replace("<", "&lt;")).replace(">", "&gt;");
        }
        public static string escapeAttributeValue(string value) {
            return (escapeText(value)).replace("\"", "&quot;");
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class HtmlWriter__Anonymous_0 : Mammoth.Couscous.java.util.function.Consumer<HtmlNode> {
        internal java.lang.StringBuilder _builder;
        internal HtmlWriter__Anonymous_0(java.lang.StringBuilder builder) {
            _builder = builder;
        }
        public void accept(HtmlNode child) {
            HtmlWriter.write(child, _builder);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class HtmlWriter__Anonymous_1 : HtmlNode__Visitor {
        internal java.lang.StringBuilder _builder;
        internal HtmlWriter__Anonymous_1(java.lang.StringBuilder builder) {
            _builder = builder;
        }
        public void visit(HtmlElement element) {
            ((_builder).append("<")).append(element.getTagName());
            HtmlWriter.generateAttributes(element.getAttributes(), _builder);
            if (element.isVoid()) {
                (_builder).append(" />");
            } else {
                (_builder).append(">");
                (element.getChildren()).forEach(new HtmlWriter__Anonymous_0(_builder));
                (((_builder).append("</")).append(element.getTagName())).append(">");
            }
        }
        public void visit(HtmlTextNode node) {
            (_builder).append(HtmlWriter.escapeText(node.getValue()));
        }
        public void visit(HtmlForceWrite forceWrite) {
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.html {
    internal class HtmlWriter__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<Mammoth.Couscous.java.util.Map__Entry<string, string>, string> {
        public string apply(Mammoth.Couscous.java.util.Map__Entry<string, string> arg0) {
            return arg0.getKey();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.results {
    internal static class InternalResult {
        public static InternalResult<Mammoth.Couscous.java.util.List<R>> flatMap<T, R>(java.lang.Iterable<T> iterable, Mammoth.Couscous.java.util.function.Function<T, InternalResult<R>> function) {
            Mammoth.Couscous.java.util.List<InternalResult<R>> results = util.Lists.eagerMap<T, InternalResult<R>>(iterable, function);
            return new InternalResult<Mammoth.Couscous.java.util.List<R>>(util.Lists.eagerMap<InternalResult<R>, R>(results, new InternalResult__Anonymous_0<R>()), util.Iterables.lazyFlatMap<InternalResult<R>, string>(results, new InternalResult__Anonymous_1<R>()));
        }
        public static InternalResult<R> flatMap<T1, T2, R>(InternalResult<T1> first, InternalResult<T2> second, Mammoth.Couscous.java.util.function.BiFunction<T1, T2, InternalResult<R>> function) {
            InternalResult<R> intermediateResult = function.apply(first._value, second._value);
            return new InternalResult<R>(intermediateResult._value, util.Iterables.lazyConcat<string>(util.Iterables.lazyConcat<string>(first._warnings, second._warnings), intermediateResult._warnings));
        }
        public static InternalResult<R> map<T1, T2, R>(InternalResult<T1> first, InternalResult<T2> second, Mammoth.Couscous.java.util.function.BiFunction<T1, T2, R> function) {
            return new InternalResult<R>(function.apply(first._value, second._value), util.Iterables.lazyConcat<string>(first._warnings, second._warnings));
        }
        public static InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>> empty() {
            return new InternalResult<Mammoth.Couscous.java.util.Optional<documents.Style>>(java.util.Optional.empty<documents.Style>(), util.Lists.list<string>());
        }
        public static InternalResult<T> success<T>(T value) {
            return new InternalResult<T>(value, util.Lists.list<string>());
        }
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.results {
    internal class InternalResult<T> {
        internal T _value;
        internal java.lang.Iterable<string> _warnings;
        internal InternalResult(T value, java.lang.Iterable<string> warnings) {
            _value = value;
            _warnings = warnings;
        }
        public T getValue() {
            return _value;
        }
        public java.lang.Iterable<string> getWarnings() {
            return _warnings;
        }
        public InternalResult<R> map<R>(Mammoth.Couscous.java.util.function.Function<T, R> function) {
            return new InternalResult<R>(function.apply(_value), _warnings);
        }
        public InternalResult<R> flatMap<R>(Mammoth.Couscous.java.util.function.Function<T, InternalResult<R>> function) {
            InternalResult<R> intermediateResult = function.apply(_value);
            return new InternalResult<R>(intermediateResult._value, util.Iterables.lazyConcat<string>(_warnings, intermediateResult._warnings));
        }
        public Result<T> toResult() {
            Mammoth.Couscous.java.util.Set<string> warnings = util.Sets.toSet<string>(_warnings);
            return new InternalResult__Anonymous_2<T>(this, warnings);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.results {
    internal static class InternalResult__Anonymous_0 {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.results {
    internal class InternalResult__Anonymous_0<R> : Mammoth.Couscous.java.util.function.Function<InternalResult<R>, R> {
        public R apply(InternalResult<R> result) {
            return result._value;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.results {
    internal static class InternalResult__Anonymous_1 {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.results {
    internal class InternalResult__Anonymous_1<R> : Mammoth.Couscous.java.util.function.Function<InternalResult<R>, java.lang.Iterable<string>> {
        public java.lang.Iterable<string> apply(InternalResult<R> result) {
            return result._warnings;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.results {
    internal static class InternalResult__Anonymous_2 {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.results {
    internal class InternalResult__Anonymous_2<T> : Result<T> {
        internal InternalResult<T> _this_org__zwobble__mammoth__internal__results__InternalResult;
        internal Mammoth.Couscous.java.util.Set<string> _warnings;
        internal InternalResult__Anonymous_2(InternalResult<T> this_org__zwobble__mammoth__internal__results__InternalResult, Mammoth.Couscous.java.util.Set<string> warnings) {
            _this_org__zwobble__mammoth__internal__results__InternalResult = this_org__zwobble__mammoth__internal__results__InternalResult;
            _warnings = warnings;
        }
        public T getValue() {
            return (_this_org__zwobble__mammoth__internal__results__InternalResult)._value;
        }
        public Mammoth.Couscous.java.util.Set<string> getWarnings() {
            return _warnings;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class BreakMatcher : DocumentElementMatcher<documents.Break> {
        internal static BreakMatcher _LINE_BREAK;
        internal static BreakMatcher _PAGE_BREAK;
        internal static BreakMatcher _COLUMN_BREAK;
        internal documents.Break__Type _breakType;
        static BreakMatcher() {
            _LINE_BREAK = new BreakMatcher(documents.Break__Type._LINE);
            _PAGE_BREAK = new BreakMatcher(documents.Break__Type._PAGE);
            _COLUMN_BREAK = new BreakMatcher(documents.Break__Type._COLUMN);
        }
        internal BreakMatcher(documents.Break__Type breakType) {
            _breakType = breakType;
        }
        public bool matches(documents.Break element) {
            return (element.getType()).equals(_breakType);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class DefaultStyles {
        internal static StyleMap _DEFAULT_STYLE_MAP;
        static DefaultStyles() {
            _DEFAULT_STYLE_MAP = parsing.StyleMapParser.parseStyleMappings(util.Lists.list<string>(new string[] {"p.Heading1 => h1:fresh", "p.Heading2 => h2:fresh", "p.Heading3 => h3:fresh", "p.Heading4 => h4:fresh", "p.Heading5 => h5:fresh", "p.Heading6 => h6:fresh", "p[style-name='Heading 1'] => h1:fresh", "p[style-name='Heading 2'] => h2:fresh", "p[style-name='Heading 3'] => h3:fresh", "p[style-name='Heading 4'] => h4:fresh", "p[style-name='Heading 5'] => h5:fresh", "p[style-name='Heading 6'] => h6:fresh", "p[style-name='heading 1'] => h1:fresh", "p[style-name='heading 2'] => h2:fresh", "p[style-name='heading 3'] => h3:fresh", "p[style-name='heading 4'] => h4:fresh", "p[style-name='heading 5'] => h5:fresh", "p[style-name='heading 6'] => h6:fresh", "r[style-name='Strong'] => strong", "p[style-name='footnote text'] => p", "r[style-name='footnote reference'] =>", "p[style-name='endnote text'] => p", "r[style-name='endnote reference'] =>", "p[style-name='annotation text'] => p", "r[style-name='annotation reference'] =>", "p[style-name='Footnote'] => p", "r[style-name='Footnote anchor'] =>", "p[style-name='Endnote'] => p", "r[style-name='Endnote anchor'] =>", "p:unordered-list(1) => ul > li:fresh", "p:unordered-list(2) => ul|ol > li > ul > li:fresh", "p:unordered-list(3) => ul|ol > li > ul|ol > li > ul > li:fresh", "p:unordered-list(4) => ul|ol > li > ul|ol > li > ul|ol > li > ul > li:fresh", "p:unordered-list(5) => ul|ol > li > ul|ol > li > ul|ol > li > ul|ol > li > ul > li:fresh", "p:ordered-list(1) => ol > li:fresh", "p:ordered-list(2) => ul|ol > li > ol > li:fresh", "p:ordered-list(3) => ul|ol > li > ul|ol > li > ol > li:fresh", "p:ordered-list(4) => ul|ol > li > ul|ol > li > ul|ol > li > ol > li:fresh", "p:ordered-list(5) => ul|ol > li > ul|ol > li > ul|ol > li > ul|ol > li > ol > li:fresh", "r[style-name='Hyperlink'] =>", "p[style-name='Normal'] => p:fresh"}));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal interface DocumentElementMatcher<T> {
        bool matches(T element);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class DocumentElementMatching {
        public static bool matchesStyle(Mammoth.Couscous.java.util.Optional<string> styleId, Mammoth.Couscous.java.util.Optional<StringMatcher> styleName, Mammoth.Couscous.java.util.Optional<documents.Style> style) {
            return matchesStyleId(styleId, style) && matchesStyleName(styleName, style);
        }
        public static bool matchesStyleId(Mammoth.Couscous.java.util.Optional<string> styleId, Mammoth.Couscous.java.util.Optional<documents.Style> style) {
            return matches<string, string>(styleId, style.map<string>(new DocumentElementMatching__Anonymous_0()), new DocumentElementMatching__Anonymous_1());
        }
        public static bool matchesStyleName(Mammoth.Couscous.java.util.Optional<StringMatcher> styleName, Mammoth.Couscous.java.util.Optional<documents.Style> style) {
            return matches<StringMatcher, string>(styleName, style.flatMap<string>(new DocumentElementMatching__Anonymous_2()), new DocumentElementMatching__Anonymous_3());
        }
        public static bool matches<T, U>(Mammoth.Couscous.java.util.Optional<T> required, Mammoth.Couscous.java.util.Optional<U> actual, Mammoth.Couscous.java.util.function.BiPredicate<T, U> areEqual) {
            return (required.map<bool>(new DocumentElementMatching__Anonymous_5<T, U>(actual, areEqual))).orElse(true);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class DocumentElementMatching__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<documents.Style, string> {
        public string apply(documents.Style arg0) {
            return arg0.getStyleId();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class DocumentElementMatching__Anonymous_1 : Mammoth.Couscous.java.util.function.BiPredicate<string, string> {
        public bool test(string arg0, string arg1) {
            return arg0.Equals(arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class DocumentElementMatching__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<documents.Style, Mammoth.Couscous.java.util.Optional<string>> {
        public Mammoth.Couscous.java.util.Optional<string> apply(documents.Style arg0) {
            return arg0.getName();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class DocumentElementMatching__Anonymous_3 : Mammoth.Couscous.java.util.function.BiPredicate<StringMatcher, string> {
        public bool test(StringMatcher arg0, string arg1) {
            return arg0.matches(arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal static class DocumentElementMatching__Anonymous_4 {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class DocumentElementMatching__Anonymous_4<U, T> : Mammoth.Couscous.java.util.function.Function<U, bool> {
        internal Mammoth.Couscous.java.util.function.BiPredicate<T, U> _areEqual;
        internal T _requiredValue;
        internal DocumentElementMatching__Anonymous_4(Mammoth.Couscous.java.util.function.BiPredicate<T, U> areEqual, T requiredValue) {
            _areEqual = areEqual;
            _requiredValue = requiredValue;
        }
        public bool apply(U actualValue) {
            return (_areEqual).test(_requiredValue, actualValue);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal static class DocumentElementMatching__Anonymous_5 {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class DocumentElementMatching__Anonymous_5<T, U> : Mammoth.Couscous.java.util.function.Function<T, bool> {
        internal Mammoth.Couscous.java.util.Optional<U> _actual;
        internal Mammoth.Couscous.java.util.function.BiPredicate<T, U> _areEqual;
        internal DocumentElementMatching__Anonymous_5(Mammoth.Couscous.java.util.Optional<U> actual, Mammoth.Couscous.java.util.function.BiPredicate<T, U> areEqual) {
            _actual = actual;
            _areEqual = areEqual;
        }
        public bool apply(T requiredValue) {
            return ((_actual).map<bool>(new DocumentElementMatching__Anonymous_4<U, T>(_areEqual, requiredValue))).orElse(false);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class EqualToStringMatcher : StringMatcher {
        internal string _value;
        internal EqualToStringMatcher(string value) {
            _value = value;
        }
        public bool matches(string value) {
            return (_value).equalsIgnoreCase(value);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class HtmlPath_static {
        internal static HtmlPath _EMPTY;
        internal static HtmlPath _IGNORE;
        static HtmlPath_static() {
            _EMPTY = new HtmlPathElements(util.Lists.list<HtmlPathElement>());
            _IGNORE = Ignore._INSTANCE;
        }
        public static HtmlPath elements(HtmlPathElement[] elements) {
            return new HtmlPathElements(java.util.Arrays.asList<HtmlPathElement>(elements));
        }
        public static HtmlPath element(string tagName) {
            return element(tagName, util.Maps.map<string, string>());
        }
        public static HtmlPath element(string tagName, Mammoth.Couscous.java.util.Map<string, string> attributes) {
            html.HtmlTag tag = new html.HtmlTag(util.Lists.list<string>(tagName), attributes, false, "");
            return new HtmlPathElements(util.Lists.list<HtmlPathElement>(new HtmlPathElement(tag)));
        }
        public static HtmlPath collapsibleElement(string tagName) {
            return collapsibleElement(tagName, util.Maps.map<string, string>());
        }
        public static HtmlPath collapsibleElement(Mammoth.Couscous.java.util.List<string> tagNames) {
            return collapsibleElement(tagNames, util.Maps.map<string, string>());
        }
        public static HtmlPath collapsibleElement(string tagName, Mammoth.Couscous.java.util.Map<string, string> attributes) {
            return collapsibleElement(util.Lists.list<string>(tagName), attributes);
        }
        public static HtmlPath collapsibleElement(Mammoth.Couscous.java.util.List<string> tagNames, Mammoth.Couscous.java.util.Map<string, string> attributes) {
            html.HtmlTag tag = new html.HtmlTag(tagNames, attributes, true, "");
            return new HtmlPathElements(util.Lists.list<HtmlPathElement>(new HtmlPathElement(tag)));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal interface HtmlPath {
        Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> wrap(Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> generateNodes);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class HtmlPathElement {
        internal html.HtmlTag _tag;
        internal HtmlPathElement(html.HtmlTag tag) {
            _tag = tag;
        }
        public Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> wrap(Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> generateNodes) {
            return new HtmlPathElement__Anonymous_0(this, generateNodes);
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> wrapNodes(Mammoth.Couscous.java.util.List<html.HtmlNode> nodes) {
            return util.Lists.list<html.HtmlNode>(new html.HtmlElement(_tag, nodes));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class HtmlPathElement__Anonymous_0 : Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        internal HtmlPathElement _this_org__zwobble__mammoth__internal__styles__HtmlPathElement;
        internal Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> _generateNodes;
        internal HtmlPathElement__Anonymous_0(HtmlPathElement this_org__zwobble__mammoth__internal__styles__HtmlPathElement, Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> generateNodes) {
            _this_org__zwobble__mammoth__internal__styles__HtmlPathElement = this_org__zwobble__mammoth__internal__styles__HtmlPathElement;
            _generateNodes = generateNodes;
        }
        public Mammoth.Couscous.java.util.List<html.HtmlNode> get() {
            return (_this_org__zwobble__mammoth__internal__styles__HtmlPathElement).wrapNodes((_generateNodes).get());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class HtmlPathElements : HtmlPath {
        internal Mammoth.Couscous.java.util.List<HtmlPathElement> _elements;
        internal HtmlPathElements(Mammoth.Couscous.java.util.List<HtmlPathElement> elements) {
            _elements = elements;
        }
        public Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> wrap(Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> generateNodes) {
             {
                Mammoth.Couscous.java.util.Iterator<HtmlPathElement> _couscous_desugar_foreach_to_for6 = (util.Lists.reversed<HtmlPathElement>(_elements)).iterator();
                while (_couscous_desugar_foreach_to_for6.hasNext()) {
                    HtmlPathElement element = _couscous_desugar_foreach_to_for6.next();
                    generateNodes = element.wrap(generateNodes);
                }
            }
            return generateNodes;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class Ignore : HtmlPath {
        internal static HtmlPath _INSTANCE;
        static Ignore() {
            _INSTANCE = new Ignore();
        }
        public Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> wrap(Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> generateNodes) {
            return new Ignore__Anonymous_0();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class Ignore__Anonymous_0 : Mammoth.Couscous.java.util.function.Supplier<Mammoth.Couscous.java.util.List<html.HtmlNode>> {
        public Mammoth.Couscous.java.util.List<html.HtmlNode> get() {
            return util.Lists.list<html.HtmlNode>();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class ParagraphMatcher : DocumentElementMatcher<documents.Paragraph> {
        internal static ParagraphMatcher _ANY;
        internal Mammoth.Couscous.java.util.Optional<string> _styleId;
        internal Mammoth.Couscous.java.util.Optional<StringMatcher> _styleName;
        internal Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> _numbering;
        static ParagraphMatcher() {
            _ANY = new ParagraphMatcher(java.util.Optional.empty<string>(), java.util.Optional.empty<StringMatcher>(), java.util.Optional.empty<documents.NumberingLevel>());
        }
        internal ParagraphMatcher(Mammoth.Couscous.java.util.Optional<string> styleId, Mammoth.Couscous.java.util.Optional<StringMatcher> styleName, Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> numbering) {
            _styleId = styleId;
            _styleName = styleName;
            _numbering = numbering;
        }
        public static ParagraphMatcher styleId(string styleId) {
            return new ParagraphMatcher(java.util.Optional.of<string>(styleId), java.util.Optional.empty<StringMatcher>(), java.util.Optional.empty<documents.NumberingLevel>());
        }
        public static ParagraphMatcher styleName(string styleName) {
            return Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.ParagraphMatcher.styleName(new EqualToStringMatcher(styleName));
        }
        public static ParagraphMatcher styleName(StringMatcher styleName) {
            return new ParagraphMatcher(java.util.Optional.empty<string>(), java.util.Optional.of<StringMatcher>(styleName), java.util.Optional.empty<documents.NumberingLevel>());
        }
        public static ParagraphMatcher orderedList(string level) {
            return new ParagraphMatcher(java.util.Optional.empty<string>(), java.util.Optional.empty<StringMatcher>(), java.util.Optional.of<documents.NumberingLevel>(documents.NumberingLevel.ordered(level)));
        }
        public static ParagraphMatcher unorderedList(string level) {
            return new ParagraphMatcher(java.util.Optional.empty<string>(), java.util.Optional.empty<StringMatcher>(), java.util.Optional.of<documents.NumberingLevel>(documents.NumberingLevel.unordered(level)));
        }
        public bool matches(documents.Paragraph paragraph) {
            return matchesStyle(paragraph) && matchesNumbering(paragraph);
        }
        public bool matchesStyle(documents.Paragraph paragraph) {
            return DocumentElementMatching.matchesStyle(_styleId, _styleName, paragraph.getStyle());
        }
        public bool matchesNumbering(documents.Paragraph paragraph) {
            return DocumentElementMatching.matches<documents.NumberingLevel, documents.NumberingLevel>(_numbering, paragraph.getNumbering(), new ParagraphMatcher__Anonymous_0());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class ParagraphMatcher__Anonymous_0 : Mammoth.Couscous.java.util.function.BiPredicate<documents.NumberingLevel, documents.NumberingLevel> {
        public bool test(documents.NumberingLevel first, documents.NumberingLevel second) {
            return first.isOrdered() == second.isOrdered() && (first.getLevelIndex()).equalsIgnoreCase(second.getLevelIndex());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class RunMatcher : DocumentElementMatcher<documents.Run> {
        internal static RunMatcher _ANY;
        internal Mammoth.Couscous.java.util.Optional<string> _styleId;
        internal Mammoth.Couscous.java.util.Optional<StringMatcher> _styleName;
        static RunMatcher() {
            _ANY = new RunMatcher(java.util.Optional.empty<string>(), java.util.Optional.empty<StringMatcher>());
        }
        internal RunMatcher(Mammoth.Couscous.java.util.Optional<string> styleId, Mammoth.Couscous.java.util.Optional<StringMatcher> styleName) {
            _styleId = styleId;
            _styleName = styleName;
        }
        public static RunMatcher styleId(string styleId) {
            return new RunMatcher(java.util.Optional.of<string>(styleId), java.util.Optional.empty<StringMatcher>());
        }
        public static RunMatcher styleName(string styleName) {
            return new RunMatcher(java.util.Optional.empty<string>(), java.util.Optional.of<StringMatcher>(new EqualToStringMatcher(styleName)));
        }
        public bool matches(documents.Run run) {
            return DocumentElementMatching.matchesStyle(_styleId, _styleName, run.getStyle());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StartsWithStringMatcher : StringMatcher {
        internal string _prefix;
        internal StartsWithStringMatcher(string prefix) {
            _prefix = prefix;
        }
        public bool matches(string value) {
            return util.Strings.startsWithIgnoreCase(value, _prefix);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal interface StringMatcher {
        bool matches(string value);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMap {
        internal static StyleMap _EMPTY;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _bold;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _italic;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _underline;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _strikethrough;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _smallCaps;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _commentReference;
        internal Mammoth.Couscous.java.util.List<StyleMapping<documents.Paragraph>> _paragraphStyles;
        internal Mammoth.Couscous.java.util.List<StyleMapping<documents.Run>> _runStyles;
        internal Mammoth.Couscous.java.util.List<StyleMapping<documents.Table>> _tableStyles;
        internal Mammoth.Couscous.java.util.List<StyleMapping<documents.Break>> _breakStyles;
        static StyleMap() {
            _EMPTY = (new StyleMapBuilder()).build();
        }
        internal StyleMap(Mammoth.Couscous.java.util.Optional<HtmlPath> bold, Mammoth.Couscous.java.util.Optional<HtmlPath> italic, Mammoth.Couscous.java.util.Optional<HtmlPath> underline, Mammoth.Couscous.java.util.Optional<HtmlPath> strikethrough, Mammoth.Couscous.java.util.Optional<HtmlPath> smallCaps, Mammoth.Couscous.java.util.Optional<HtmlPath> commentReference, Mammoth.Couscous.java.util.List<StyleMapping<documents.Paragraph>> paragraphStyles, Mammoth.Couscous.java.util.List<StyleMapping<documents.Run>> runStyles, Mammoth.Couscous.java.util.List<StyleMapping<documents.Table>> tableStyles, Mammoth.Couscous.java.util.List<StyleMapping<documents.Break>> breakStyles) {
            _bold = bold;
            _italic = italic;
            _underline = underline;
            _strikethrough = strikethrough;
            _smallCaps = smallCaps;
            _commentReference = commentReference;
            _paragraphStyles = paragraphStyles;
            _runStyles = runStyles;
            _tableStyles = tableStyles;
            _breakStyles = breakStyles;
        }
        public static StyleMapBuilder builder() {
            return new StyleMapBuilder();
        }
        public static StyleMap merge(StyleMap high, StyleMap low) {
            return new StyleMap(util.Optionals.first<HtmlPath>(high._bold, low._bold), util.Optionals.first<HtmlPath>(high._italic, low._italic), util.Optionals.first<HtmlPath>(high._underline, low._underline), util.Optionals.first<HtmlPath>(high._strikethrough, low._strikethrough), util.Optionals.first<HtmlPath>(high._smallCaps, low._smallCaps), util.Optionals.first<HtmlPath>(high._commentReference, low._commentReference), util.Lists.eagerConcat<StyleMapping<documents.Paragraph>>(high._paragraphStyles, low._paragraphStyles), util.Lists.eagerConcat<StyleMapping<documents.Run>>(high._runStyles, low._runStyles), util.Lists.eagerConcat<StyleMapping<documents.Table>>(high._tableStyles, low._tableStyles), util.Lists.eagerConcat<StyleMapping<documents.Break>>(high._breakStyles, low._breakStyles));
        }
        public StyleMap update(StyleMap styleMap) {
            return merge(styleMap, this);
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getBold() {
            return _bold;
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getItalic() {
            return _italic;
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getUnderline() {
            return _underline;
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getStrikethrough() {
            return _strikethrough;
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getSmallCaps() {
            return _smallCaps;
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getCommentReference() {
            return _commentReference;
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getParagraphHtmlPath(documents.Paragraph paragraph) {
            return (util.Iterables.tryFind<StyleMapping<documents.Paragraph>>(_paragraphStyles, new StyleMap__Anonymous_0(paragraph))).map<HtmlPath>(new StyleMap__Anonymous_1());
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getRunHtmlPath(documents.Run run) {
            return (util.Iterables.tryFind<StyleMapping<documents.Run>>(_runStyles, new StyleMap__Anonymous_2(run))).map<HtmlPath>(new StyleMap__Anonymous_3());
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getTableHtmlPath(documents.Table table) {
            return (util.Iterables.tryFind<StyleMapping<documents.Table>>(_tableStyles, new StyleMap__Anonymous_4(table))).map<HtmlPath>(new StyleMap__Anonymous_5());
        }
        public Mammoth.Couscous.java.util.Optional<HtmlPath> getBreakHtmlPath(documents.Break breakElement) {
            return (util.Iterables.tryFind<StyleMapping<documents.Break>>(_breakStyles, new StyleMap__Anonymous_6(breakElement))).map<HtmlPath>(new StyleMap__Anonymous_7());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMap__Anonymous_0 : Mammoth.Couscous.java.util.function.Predicate<StyleMapping<documents.Paragraph>> {
        internal documents.Paragraph _paragraph;
        internal StyleMap__Anonymous_0(documents.Paragraph paragraph) {
            _paragraph = paragraph;
        }
        public bool test(StyleMapping<documents.Paragraph> styleMapping) {
            return styleMapping.matches(_paragraph);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMap__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<StyleMapping<documents.Paragraph>, HtmlPath> {
        public HtmlPath apply(StyleMapping<documents.Paragraph> arg0) {
            return arg0.getHtmlPath();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMap__Anonymous_2 : Mammoth.Couscous.java.util.function.Predicate<StyleMapping<documents.Run>> {
        internal documents.Run _run;
        internal StyleMap__Anonymous_2(documents.Run run) {
            _run = run;
        }
        public bool test(StyleMapping<documents.Run> styleMapping) {
            return styleMapping.matches(_run);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMap__Anonymous_3 : Mammoth.Couscous.java.util.function.Function<StyleMapping<documents.Run>, HtmlPath> {
        public HtmlPath apply(StyleMapping<documents.Run> arg0) {
            return arg0.getHtmlPath();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMap__Anonymous_4 : Mammoth.Couscous.java.util.function.Predicate<StyleMapping<documents.Table>> {
        internal documents.Table _table;
        internal StyleMap__Anonymous_4(documents.Table table) {
            _table = table;
        }
        public bool test(StyleMapping<documents.Table> styleMapping) {
            return styleMapping.matches(_table);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMap__Anonymous_5 : Mammoth.Couscous.java.util.function.Function<StyleMapping<documents.Table>, HtmlPath> {
        public HtmlPath apply(StyleMapping<documents.Table> arg0) {
            return arg0.getHtmlPath();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMap__Anonymous_6 : Mammoth.Couscous.java.util.function.Predicate<StyleMapping<documents.Break>> {
        internal documents.Break _breakElement;
        internal StyleMap__Anonymous_6(documents.Break breakElement) {
            _breakElement = breakElement;
        }
        public bool test(StyleMapping<documents.Break> styleMapping) {
            return styleMapping.matches(_breakElement);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMap__Anonymous_7 : Mammoth.Couscous.java.util.function.Function<StyleMapping<documents.Break>, HtmlPath> {
        public HtmlPath apply(StyleMapping<documents.Break> arg0) {
            return arg0.getHtmlPath();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMapBuilder {
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _underline;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _strikethrough;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _smallCaps;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _bold;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _italic;
        internal Mammoth.Couscous.java.util.Optional<HtmlPath> _commentReference;
        internal Mammoth.Couscous.java.util.List<StyleMapping<documents.Paragraph>> _paragraphStyles;
        internal Mammoth.Couscous.java.util.List<StyleMapping<documents.Run>> _runStyles;
        internal Mammoth.Couscous.java.util.List<StyleMapping<documents.Table>> _tableStyles;
        internal Mammoth.Couscous.java.util.List<StyleMapping<documents.Break>> _breakStyles;
        internal StyleMapBuilder() {
            _paragraphStyles = new Mammoth.Couscous.java.util.ArrayList<StyleMapping<documents.Paragraph>>();
            _runStyles = new Mammoth.Couscous.java.util.ArrayList<StyleMapping<documents.Run>>();
            _tableStyles = new Mammoth.Couscous.java.util.ArrayList<StyleMapping<documents.Table>>();
            _breakStyles = new Mammoth.Couscous.java.util.ArrayList<StyleMapping<documents.Break>>();
            _bold = java.util.Optional.empty<HtmlPath>();
            _underline = java.util.Optional.empty<HtmlPath>();
            _strikethrough = java.util.Optional.empty<HtmlPath>();
            _smallCaps = java.util.Optional.empty<HtmlPath>();
            _italic = java.util.Optional.empty<HtmlPath>();
            _commentReference = java.util.Optional.empty<HtmlPath>();
        }
        public StyleMapBuilder bold(HtmlPath path) {
            _bold = java.util.Optional.of<HtmlPath>(path);
            return this;
        }
        public StyleMapBuilder italic(HtmlPath path) {
            _italic = java.util.Optional.of<HtmlPath>(path);
            return this;
        }
        public StyleMapBuilder underline(HtmlPath path) {
            _underline = java.util.Optional.of<HtmlPath>(path);
            return this;
        }
        public StyleMapBuilder strikethrough(HtmlPath path) {
            _strikethrough = java.util.Optional.of<HtmlPath>(path);
            return this;
        }
        public StyleMapBuilder smallCaps(HtmlPath path) {
            _smallCaps = java.util.Optional.of<HtmlPath>(path);
            return this;
        }
        public StyleMapBuilder commentReference(HtmlPath path) {
            _commentReference = java.util.Optional.of<HtmlPath>(path);
            return this;
        }
        public StyleMapBuilder mapParagraph(ParagraphMatcher matcher, HtmlPath path) {
            (_paragraphStyles).add(new StyleMapping<documents.Paragraph>(matcher, path));
            return this;
        }
        public StyleMapBuilder mapRun(RunMatcher matcher, HtmlPath path) {
            (_runStyles).add(new StyleMapping<documents.Run>(matcher, path));
            return this;
        }
        public StyleMapBuilder mapTable(TableMatcher matcher, HtmlPath path) {
            (_tableStyles).add(new StyleMapping<documents.Table>(matcher, path));
            return this;
        }
        public StyleMapBuilder mapBreak(BreakMatcher matcher, HtmlPath path) {
            (_breakStyles).add(new StyleMapping<documents.Break>(matcher, path));
            return this;
        }
        public StyleMap build() {
            return new StyleMap(_bold, _italic, _underline, _strikethrough, _smallCaps, _commentReference, _paragraphStyles, _runStyles, _tableStyles, _breakStyles);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal static class StyleMapping {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class StyleMapping<T> {
        internal DocumentElementMatcher<T> _matcher;
        internal HtmlPath _htmlPath;
        internal StyleMapping(DocumentElementMatcher<T> matcher, HtmlPath htmlPath) {
            _matcher = matcher;
            _htmlPath = htmlPath;
        }
        public bool matches(T element) {
            return (_matcher).matches(element);
        }
        public HtmlPath getHtmlPath() {
            return _htmlPath;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles {
    internal class TableMatcher : DocumentElementMatcher<documents.Table> {
        internal static TableMatcher _ANY;
        internal Mammoth.Couscous.java.util.Optional<string> _styleId;
        internal Mammoth.Couscous.java.util.Optional<StringMatcher> _styleName;
        static TableMatcher() {
            _ANY = new TableMatcher(java.util.Optional.empty<string>(), java.util.Optional.empty<StringMatcher>());
        }
        internal TableMatcher(Mammoth.Couscous.java.util.Optional<string> styleId, Mammoth.Couscous.java.util.Optional<StringMatcher> styleName) {
            _styleId = styleId;
            _styleName = styleName;
        }
        public static TableMatcher styleId(string styleId) {
            return new TableMatcher(java.util.Optional.of<string>(styleId), java.util.Optional.empty<StringMatcher>());
        }
        public static TableMatcher styleName(string styleName) {
            return new TableMatcher(java.util.Optional.empty<string>(), java.util.Optional.of<StringMatcher>(new EqualToStringMatcher(styleName)));
        }
        public bool matches(documents.Table table) {
            return DocumentElementMatching.matchesStyle(_styleId, _styleName, table.getStyle());
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser {
        public static Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> parse(TokenIterator<TokenType> tokens) {
            Token<TokenType> identifier = tokens.next(TokenType._IDENTIFIER);
            switch (identifier.getValue()) {
                case "p":
                    ParagraphMatcher paragraph = parseParagraphMatcher(tokens);
                    return new DocumentMatcherParser__Anonymous_0(paragraph);
                case "r":
                    RunMatcher run = parseRunMatcher(tokens);
                    return new DocumentMatcherParser__Anonymous_1(run);
                case "table":
                    TableMatcher table = parseTableMatcher(tokens);
                    return new DocumentMatcherParser__Anonymous_2(table);
                case "b":
                    return new DocumentMatcherParser__Anonymous_3();
                case "i":
                    return new DocumentMatcherParser__Anonymous_4();
                case "u":
                    return new DocumentMatcherParser__Anonymous_5();
                case "strike":
                    return new DocumentMatcherParser__Anonymous_6();
                case "small-caps":
                    return new DocumentMatcherParser__Anonymous_7();
                case "comment-reference":
                    return new DocumentMatcherParser__Anonymous_8();
                case "br":
                    BreakMatcher breakMatcher = parseBreakMatcher(tokens);
                    return new DocumentMatcherParser__Anonymous_9(breakMatcher);
                default:
                    throw LineParseException.lineParseException<TokenType>(identifier, "Unrecognised document element: " + identifier);
            }
        }
        public static ParagraphMatcher parseParagraphMatcher(TokenIterator<TokenType> tokens) {
            Mammoth.Couscous.java.util.Optional<string> styleId = parseStyleId(tokens);
            Mammoth.Couscous.java.util.Optional<StringMatcher> styleName = parseStyleName(tokens);
            Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> numbering = parseNumbering(tokens);
            return new ParagraphMatcher(styleId, styleName, numbering);
        }
        public static RunMatcher parseRunMatcher(TokenIterator<TokenType> tokens) {
            Mammoth.Couscous.java.util.Optional<string> styleId = parseStyleId(tokens);
            Mammoth.Couscous.java.util.Optional<StringMatcher> styleName = parseStyleName(tokens);
            return new RunMatcher(styleId, styleName);
        }
        public static TableMatcher parseTableMatcher(TokenIterator<TokenType> tokens) {
            Mammoth.Couscous.java.util.Optional<string> styleId = parseStyleId(tokens);
            Mammoth.Couscous.java.util.Optional<StringMatcher> styleName = parseStyleName(tokens);
            return new TableMatcher(styleId, styleName);
        }
        public static Mammoth.Couscous.java.util.Optional<string> parseStyleId(TokenIterator<TokenType> tokens) {
            return TokenParser.parseClassName(tokens);
        }
        public static Mammoth.Couscous.java.util.Optional<StringMatcher> parseStyleName(TokenIterator<TokenType> tokens) {
            if (tokens.trySkip(TokenType._SYMBOL, "[")) {
                tokens.skip(TokenType._IDENTIFIER, "style-name");
                StringMatcher stringMatcher = parseStringMatcher(tokens);
                tokens.skip(TokenType._SYMBOL, "]");
                return java.util.Optional.of<StringMatcher>(stringMatcher);
            } else {
                return java.util.Optional.empty<StringMatcher>();
            }
        }
        public static StringMatcher parseStringMatcher(TokenIterator<TokenType> tokens) {
            if (tokens.trySkip(TokenType._SYMBOL, "=")) {
                return new EqualToStringMatcher(TokenParser.parseString(tokens));
            } else if (tokens.trySkip(TokenType._SYMBOL, "^=")) {
                return new StartsWithStringMatcher(TokenParser.parseString(tokens));
            } else {
                throw LineParseException.lineParseException<TokenType>(tokens.next(), "Expected string matcher but got token " + (tokens.next()).getValue());
            }
        }
        public static Mammoth.Couscous.java.util.Optional<documents.NumberingLevel> parseNumbering(TokenIterator<TokenType> tokens) {
            if (tokens.trySkip(TokenType._SYMBOL, ":")) {
                bool isOrdered = parseListType(tokens);
                tokens.skip(TokenType._SYMBOL, "(");
                string level = ((new java.math.BigInteger(tokens.nextValue(TokenType._INTEGER))).subtract(java.math.BigInteger._ONE)).toString();
                tokens.skip(TokenType._SYMBOL, ")");
                return java.util.Optional.of<documents.NumberingLevel>(new documents.NumberingLevel(level, isOrdered));
            } else {
                return java.util.Optional.empty<documents.NumberingLevel>();
            }
        }
        public static bool parseListType(TokenIterator<TokenType> tokens) {
            Token<TokenType> listType = tokens.next(TokenType._IDENTIFIER);
            switch (listType.getValue()) {
                case "ordered-list":
                    return true;
                case "unordered-list":
                    return false;
                default:
                    throw LineParseException.lineParseException<TokenType>(listType, "Unrecognised list type: " + listType);
            }
        }
        public static BreakMatcher parseBreakMatcher(TokenIterator<TokenType> tokens) {
            tokens.skip(TokenType._SYMBOL, "[");
            tokens.skip(TokenType._IDENTIFIER, "type");
            tokens.skip(TokenType._SYMBOL, "=");
            Token<TokenType> stringToken = tokens.next(TokenType._STRING);
            tokens.skip(TokenType._SYMBOL, "]");
            string typeName = TokenParser.parseStringToken(stringToken);
            switch (typeName) {
                case "line":
                    return BreakMatcher._LINE_BREAK;
                case "page":
                    return BreakMatcher._PAGE_BREAK;
                case "column":
                    return BreakMatcher._COLUMN_BREAK;
                default:
                    throw LineParseException.lineParseException<TokenType>(stringToken, "Unrecognised break type: " + typeName);
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_0 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        internal ParagraphMatcher _paragraph;
        internal DocumentMatcherParser__Anonymous_0(ParagraphMatcher paragraph) {
            _paragraph = paragraph;
        }
        public void accept(StyleMapBuilder builder, HtmlPath path) {
            builder.mapParagraph(_paragraph, path);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_1 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        internal RunMatcher _run;
        internal DocumentMatcherParser__Anonymous_1(RunMatcher run) {
            _run = run;
        }
        public void accept(StyleMapBuilder builder, HtmlPath path) {
            builder.mapRun(_run, path);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_2 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        internal TableMatcher _table;
        internal DocumentMatcherParser__Anonymous_2(TableMatcher table) {
            _table = table;
        }
        public void accept(StyleMapBuilder builder, HtmlPath path) {
            builder.mapTable(_table, path);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_3 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        public void accept(StyleMapBuilder arg0, HtmlPath arg1) {
            arg0.bold(arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_4 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        public void accept(StyleMapBuilder arg0, HtmlPath arg1) {
            arg0.italic(arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_5 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        public void accept(StyleMapBuilder arg0, HtmlPath arg1) {
            arg0.underline(arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_6 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        public void accept(StyleMapBuilder arg0, HtmlPath arg1) {
            arg0.strikethrough(arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_7 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        public void accept(StyleMapBuilder arg0, HtmlPath arg1) {
            arg0.smallCaps(arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_8 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        public void accept(StyleMapBuilder arg0, HtmlPath arg1) {
            arg0.commentReference(arg1);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class DocumentMatcherParser__Anonymous_9 : Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> {
        internal BreakMatcher _breakMatcher;
        internal DocumentMatcherParser__Anonymous_9(BreakMatcher breakMatcher) {
            _breakMatcher = breakMatcher;
        }
        public void accept(StyleMapBuilder builder, HtmlPath path) {
            builder.mapBreak(_breakMatcher, path);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class EscapeSequences {
        internal static Mammoth.Couscous.java.util.regex.Pattern _PATTERN;
        static EscapeSequences() {
            _PATTERN = java.util.regex.Pattern.compile("\\\\(.)");
        }
        public static string decode(string value) {
            Mammoth.Couscous.java.util.regex.Matcher matcher = (_PATTERN).matcher(value);
            java.lang.StringBuilder decoded = new java.lang.StringBuilder();
            int lastIndex = 0;
            while (matcher.find()) {
                decoded.append(value.Substring(lastIndex, matcher.start() - lastIndex));
                decoded.append(escapeSequence(matcher.group(1)));
                lastIndex = matcher.end();
            }
            decoded.append(value.Substring(lastIndex, (value.Length) - lastIndex));
            return decoded.toString();
        }
        public static char escapeSequence(string code) {
            switch (code) {
                case "n":
                    return '\n';
                case "r":
                    return '\r';
                case "t":
                    return '\t';
                default:
                    return code.charAt(0);
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class HtmlPathParser {
        public static HtmlPath parse(TokenIterator<TokenType> tokens) {
            if (tokens.trySkip(TokenType._SYMBOL, "!")) {
                return HtmlPath_static._IGNORE;
            } else {
                return parseHtmlPathElements(tokens);
            }
        }
        public static HtmlPath parseHtmlPathElements(TokenIterator<TokenType> tokens) {
            Mammoth.Couscous.java.util.List<HtmlPathElement> elements = new Mammoth.Couscous.java.util.ArrayList<HtmlPathElement>();
            if (tokens.peekTokenType() == TokenType._IDENTIFIER) {
                HtmlPathElement element = parseElement(tokens);
                elements.add(element);
                while ((tokens.peekTokenType() == TokenType._WHITESPACE) && tokens.isNext(1, TokenType._SYMBOL, ">")) {
                    tokens.skip(TokenType._WHITESPACE);
                    tokens.skip(TokenType._SYMBOL, ">");
                    tokens.skip(TokenType._WHITESPACE);
                    elements.add(parseElement(tokens));
                }
            }
            return new HtmlPathElements(elements);
        }
        public static HtmlPathElement parseElement(TokenIterator<TokenType> tokens) {
            Mammoth.Couscous.java.util.List<string> tagNames = parseTagNames(tokens);
            Mammoth.Couscous.java.util.List<string> classNames = parseClassNames(tokens);
            Mammoth.Couscous.java.util.Map<string, string> attributes = classNames.isEmpty() ? util.Maps.map<string, string>() : util.Maps.map<string, string>("class", java.lang.String.join(" ", classNames));
            bool isFresh = parseIsFresh(tokens);
            string separator = parseSeparator(tokens);
            return new HtmlPathElement(new html.HtmlTag(tagNames, attributes, !isFresh, separator));
        }
        public static Mammoth.Couscous.java.util.List<string> parseTagNames(TokenIterator<TokenType> tokens) {
            Mammoth.Couscous.java.util.List<string> tagNames = new Mammoth.Couscous.java.util.ArrayList<string>();
            tagNames.add(TokenParser.parseIdentifier(tokens));
            while (tokens.trySkip(TokenType._SYMBOL, "|")) {
                tagNames.add(TokenParser.parseIdentifier(tokens));
            }
            return tagNames;
        }
        public static Mammoth.Couscous.java.util.List<string> parseClassNames(TokenIterator<TokenType> tokens) {
            Mammoth.Couscous.java.util.List<string> classNames = new Mammoth.Couscous.java.util.ArrayList<string>();
            while (true) {
                Mammoth.Couscous.java.util.Optional<string> className = TokenParser.parseClassName(tokens);
                if (className.isPresent()) {
                    classNames.add(className.get());
                } else {
                    return classNames;
                }
            }
        }
        public static bool parseIsFresh(TokenIterator<TokenType> tokens) {
            return tokens.tryParse(new HtmlPathParser__Anonymous_0(tokens));
        }
        public static string parseSeparator(TokenIterator<TokenType> tokens) {
            bool isSeparator = tokens.tryParse(new HtmlPathParser__Anonymous_1(tokens));
            if (isSeparator) {
                tokens.skip(TokenType._SYMBOL, "(");
                string value = TokenParser.parseString(tokens);
                tokens.skip(TokenType._SYMBOL, ")");
                return value;
            } else {
                return "";
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class HtmlPathParser__Anonymous_0 : TokenIterator__Action {
        internal TokenIterator<TokenType> _tokens;
        internal HtmlPathParser__Anonymous_0(TokenIterator<TokenType> tokens) {
            _tokens = tokens;
        }
        public void run() {
            (_tokens).skip(TokenType._SYMBOL, ":");
            (_tokens).skip(TokenType._IDENTIFIER, "fresh");
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class HtmlPathParser__Anonymous_1 : TokenIterator__Action {
        internal TokenIterator<TokenType> _tokens;
        internal HtmlPathParser__Anonymous_1(TokenIterator<TokenType> tokens) {
            _tokens = tokens;
        }
        public void run() {
            (_tokens).skip(TokenType._SYMBOL, ":");
            (_tokens).skip(TokenType._IDENTIFIER, "separator");
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal static class RegexTokeniser {
        public static RegexTokeniser__TokenRule<T> rule<T>(T type, string regex) {
            return new RegexTokeniser__TokenRule<T>(type, java.util.regex.Pattern.compile(regex));
        }
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class RegexTokeniser<T> {
        internal Mammoth.Couscous.java.util.regex.Pattern _pattern;
        internal Mammoth.Couscous.java.util.List<T> _rules;
        internal RegexTokeniser(T unknown, Mammoth.Couscous.java.util.List<RegexTokeniser__TokenRule<T>> rules) {
            Mammoth.Couscous.java.util.List<RegexTokeniser__TokenRule<T>> allRules = new Mammoth.Couscous.java.util.ArrayList<RegexTokeniser__TokenRule<T>>(rules);
            allRules.add(RegexTokeniser.rule<T>(unknown, "."));
            _pattern = java.util.regex.Pattern.compile(java.lang.String.join("|", util.Iterables.lazyMap<RegexTokeniser__TokenRule<T>, string>(allRules, new RegexTokeniser__Anonymous_0<T>())));
            _rules = util.Lists.eagerMap<RegexTokeniser__TokenRule<T>, T>(allRules, new RegexTokeniser__Anonymous_1<T>());
        }
        public Mammoth.Couscous.java.util.List<Token<T>> tokenise(string value) {
            Mammoth.Couscous.java.util.regex.Matcher matcher = (_pattern).matcher(value);
            Mammoth.Couscous.java.util.List<Token<T>> tokens = new Mammoth.Couscous.java.util.ArrayList<Token<T>>();
            while (matcher.lookingAt()) {
                Mammoth.Couscous.java.util.Optional<int> groupIndex = util.Iterables.tryFind<int>(util.Iterables.intRange(0, (_rules).size()), new RegexTokeniser__Anonymous_2(matcher));
                if (groupIndex.isPresent()) {
                    T tokenType = (_rules).get(groupIndex.get());
                    tokens.add(new Token<T>(matcher.regionStart(), tokenType, matcher.group()));
                    matcher.region(matcher.end(), value.Length);
                } else {
                    throw new java.lang.RuntimeException("Could not find group");
                }
            }
            return tokens;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal static class RegexTokeniser__TokenRule {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class RegexTokeniser__TokenRule<T> {
        internal T _type;
        internal Mammoth.Couscous.java.util.regex.Pattern _regex;
        internal RegexTokeniser__TokenRule(T type, Mammoth.Couscous.java.util.regex.Pattern regex) {
            if ((regex.matcher("")).groupCount() != 0) {
                throw new java.lang.RuntimeException("regex cannot contain any groups");
            }
            _type = type;
            _regex = regex;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal static class RegexTokeniser__Anonymous_0 {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class RegexTokeniser__Anonymous_0<T> : Mammoth.Couscous.java.util.function.Function<RegexTokeniser__TokenRule<T>, string> {
        public string apply(RegexTokeniser__TokenRule<T> rule) {
            return ("(" + (rule._regex).pattern()) + ")";
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal static class RegexTokeniser__Anonymous_1 {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class RegexTokeniser__Anonymous_1<T> : Mammoth.Couscous.java.util.function.Function<RegexTokeniser__TokenRule<T>, T> {
        public T apply(RegexTokeniser__TokenRule<T> rule) {
            return rule._type;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class RegexTokeniser__Anonymous_2 : Mammoth.Couscous.java.util.function.Predicate<int> {
        internal Mammoth.Couscous.java.util.regex.Matcher _matcher;
        internal RegexTokeniser__Anonymous_2(Mammoth.Couscous.java.util.regex.Matcher matcher) {
            _matcher = matcher;
        }
        public bool test(int index) {
            return !java.util.Objects.isNull((_matcher).group(index + 1));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class StyleMapParser {
        public static StyleMap parse(string input) {
            return parseStyleMappings(java.util.Arrays.asList<string>(input.split("\\r?\\n")));
        }
        public static StyleMap parseStyleMappings(Mammoth.Couscous.java.util.List<string> lines) {
            StyleMapBuilder styleMap = StyleMap.builder();
             {
                int lineIndex = 0;
                while (lineIndex < lines.size()) {
                    string line = lines.get(lineIndex);
                    try {
                        handleLine(styleMap, line);
                    } catch (LineParseException exception) {
                        throw new ParseException(generateErrorMessage(line, lineIndex + 1, exception.getCharacterIndex(), exception.getMessage()));
                    }
                    lineIndex = lineIndex + 1;
                }
            }
            return styleMap.build();
        }
        public static void handleLine(StyleMapBuilder styleMap, string line) {
            if (line.startsWith("#")) {
                return;
            }
            line = line.trim();
            if (line.isEmpty()) {
                return;
            }
            (parseStyleMapping(line)).accept(styleMap);
        }
        public static Mammoth.Couscous.java.util.function.Consumer<StyleMapBuilder> parseStyleMapping(string line) {
            TokenIterator<TokenType> tokens = StyleMappingTokeniser.tokenise(line);
            Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> documentMatcher = DocumentMatcherParser.parse(tokens);
            tokens.skip(TokenType._WHITESPACE);
            tokens.skip(TokenType._SYMBOL, "=>");
            HtmlPath htmlPath = parseHtmlPath(tokens);
            tokens.skip(TokenType._EOF);
            return new StyleMapParser__Anonymous_0(documentMatcher, htmlPath);
        }
        public static HtmlPath parseHtmlPath(TokenIterator<TokenType> tokens) {
            if (tokens.peekTokenType() == TokenType._EOF) {
                return HtmlPath_static._EMPTY;
            } else {
                tokens.skip(TokenType._WHITESPACE);
                return HtmlPathParser.parse(tokens);
            }
        }
        public static string generateErrorMessage(string line, int lineNumber, int characterIndex, string message) {
            return ((((((((("error reading style map at line " + lineNumber) + ", character ") + (characterIndex + 1)) + ": ") + message) + "\n\n") + line) + "\n") + repeatString(" ", characterIndex)) + "^";
        }
        public static string repeatString(string value, int times) {
            java.lang.StringBuilder builder = new java.lang.StringBuilder();
             {
                int i = 0;
                while (i < times) {
                    builder.append(value);
                    i = i + 1;
                }
            }
            return builder.toString();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class StyleMapParser__Anonymous_0 : Mammoth.Couscous.java.util.function.Consumer<StyleMapBuilder> {
        internal Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> _documentMatcher;
        internal HtmlPath _htmlPath;
        internal StyleMapParser__Anonymous_0(Mammoth.Couscous.java.util.function.BiConsumer<StyleMapBuilder, HtmlPath> documentMatcher, HtmlPath htmlPath) {
            _documentMatcher = documentMatcher;
            _htmlPath = htmlPath;
        }
        public void accept(StyleMapBuilder styleMap) {
            (_documentMatcher).accept(styleMap, _htmlPath);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class StyleMappingTokeniser {
        public static TokenIterator<TokenType> tokenise(string line) {
            return new TokenIterator<TokenType>(tokeniseToList(line), new Token<TokenType>(line.Length, TokenType._EOF, ""));
        }
        public static Mammoth.Couscous.java.util.List<Token<TokenType>> tokeniseToList(string line) {
            string stringPrefix = "'(?:(?:\\\\.|[^'])*)";
            string identifierCharacter = "(?:[a-zA-Z\\-_]|\\\\.)";
            RegexTokeniser<TokenType> tokeniser = new RegexTokeniser<TokenType>(TokenType._UNKNOWN, util.Lists.list<RegexTokeniser__TokenRule<TokenType>>(new RegexTokeniser__TokenRule<TokenType>[] {RegexTokeniser.rule<TokenType>(TokenType._IDENTIFIER, ((identifierCharacter + "(?:") + identifierCharacter) + "|[0-9])*"), RegexTokeniser.rule<TokenType>(TokenType._SYMBOL, ":|>|=>|\\^=|=|\\(|\\)|\\[|\\]|\\||!|\\."), RegexTokeniser.rule<TokenType>(TokenType._WHITESPACE, "\\s+"), RegexTokeniser.rule<TokenType>(TokenType._STRING, stringPrefix + "'"), RegexTokeniser.rule<TokenType>(TokenType._UNTERMINATED_STRING, stringPrefix), RegexTokeniser.rule<TokenType>(TokenType._INTEGER, "[0-9]+")}));
            return tokeniser.tokenise(line);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal static class Token {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class Token<T> {
        internal int _characterIndex;
        internal T _tokenType;
        internal string _value;
        internal Token(int characterIndex, T tokenType, string value) {
            _characterIndex = characterIndex;
            _tokenType = tokenType;
            _value = value;
        }
        public int getCharacterIndex() {
            return _characterIndex;
        }
        public T getTokenType() {
            return _tokenType;
        }
        public string getValue() {
            return _value;
        }
        public string toString() {
            return ((("Token(tokenType=" + _tokenType) + ", value=") + _value) + ")";
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal static class TokenIterator {
    }
}
namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class TokenIterator<T> {
        internal Mammoth.Couscous.java.util.List<Token<T>> _tokens;
        internal Token<T> _end;
        internal int _index;
        internal TokenIterator(Mammoth.Couscous.java.util.List<Token<T>> tokens, Token<T> end) {
            _tokens = tokens;
            _end = end;
            _index = 0;
        }
        public bool isNext(int offset, T tokenType, string value) {
            int tokenIndex = _index + offset;
            Token<T> token = getToken(tokenIndex);
            return (token.getTokenType()).equals(tokenType) && ((token.getValue()).Equals(value));
        }
        public bool isNext(T tokenType, string value) {
            return isNext(0, tokenType, value);
        }
        public bool trySkip(T tokenType, string value) {
            if (isNext(tokenType, value)) {
                skip();
                return true;
            } else {
                return false;
            }
        }
        public T peekTokenType() {
            return (getToken(_index)).getTokenType();
        }
        public Token<T> next() {
            Token<T> token = getToken(_index);
            _index = _index + 1;
            return token;
        }
        public Token<T> next(T type) {
            Token<T> token = getToken(_index);
            if ((token.getTokenType()).equals(type)) {
                _index = _index + 1;
                return token;
            } else {
                throw unexpectedTokenType(type, token);
            }
        }
        public string nextValue(T type) {
            return (next(type)).getValue();
        }
        public void skip() {
            _index = _index + 1;
        }
        public void skip(T tokenType) {
            Token<T> token = getToken(_index);
            if (!(token.getTokenType()).equals(tokenType)) {
                throw unexpectedTokenType(tokenType, token);
            }
            _index = _index + 1;
        }
        public void skip(T tokenType, string tokenValue) {
            Token<T> token = getToken(_index);
            if (!(token.getTokenType()).equals(tokenType)) {
                throw unexpectedTokenType(tokenType, token);
            }
            string actualValue = token.getValue();
            if (!(actualValue.Equals(tokenValue))) {
                throw LineParseException.lineParseException<T>(token, (((("expected " + tokenType) + " token with value ") + tokenValue) + " but value was ") + actualValue);
            }
            _index = _index + 1;
        }
        public LineParseException unexpectedTokenType(T expected, Token<T> actual) {
            return LineParseException.lineParseException<T>(actual, (("expected token of type " + expected) + " but was of type ") + actual.getTokenType());
        }
        public bool tryParse(TokenIterator__Action action) {
            int originalIndex = _index;
            try {
                action.run();
                return true;
            } catch (LineParseException) {
                _index = originalIndex;
                return false;
            }
        }
        public Token<T> getToken(int index) {
            if (index < (_tokens).size()) {
                return (_tokens).get(index);
            } else {
                return _end;
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal interface TokenIterator__Action {
        void run();
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal class TokenParser {
        public static Mammoth.Couscous.java.util.Optional<string> parseClassName(TokenIterator<TokenType> tokens) {
            if (tokens.trySkip(TokenType._SYMBOL, ".")) {
                return java.util.Optional.of<string>(parseIdentifier(tokens));
            } else {
                return java.util.Optional.empty<string>();
            }
        }
        public static string parseIdentifier(TokenIterator<TokenType> tokens) {
            return EscapeSequences.decode(tokens.nextValue(TokenType._IDENTIFIER));
        }
        public static string parseString(TokenIterator<TokenType> tokens) {
            return parseStringToken(tokens.next(TokenType._STRING));
        }
        public static string parseStringToken(Token<TokenType> token) {
            string value = token.getValue();
            return EscapeSequences.decode(value.Substring(1, ((value.Length) - 1) - 1));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.styles.parsing {
    internal enum TokenType {
        _WHITESPACE, _IDENTIFIER, _SYMBOL, _STRING, _UNTERMINATED_STRING, _INTEGER, _EOF, _UNKNOWN
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.util {
    internal interface InputStreamSupplier {
        java.io.InputStream open();
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.util {
    internal class Optionals {
        public static Mammoth.Couscous.java.util.Optional<T> first<T>(Mammoth.Couscous.java.util.Optional<T> first, Mammoth.Couscous.java.util.Optional<T> second) {
            if (first.isPresent()) {
                return first;
            } else {
                return second;
            }
        }
        public static Mammoth.Couscous.java.util.Optional<R> flatMap<T1, T2, R>(Mammoth.Couscous.java.util.Optional<T1> first, Mammoth.Couscous.java.util.Optional<T2> second, Mammoth.Couscous.java.util.function.BiFunction<T1, T2, Mammoth.Couscous.java.util.Optional<R>> function) {
            if (first.isPresent() && second.isPresent()) {
                return function.apply(first.get(), second.get());
            } else {
                return java.util.Optional.empty<R>();
            }
        }
        public static Mammoth.Couscous.java.util.Optional<R> map<T1, T2, R>(Mammoth.Couscous.java.util.Optional<T1> first, Mammoth.Couscous.java.util.Optional<T2> second, Mammoth.Couscous.java.util.function.BiFunction<T1, T2, R> function) {
            if (first.isPresent() && second.isPresent()) {
                return java.util.Optional.of<R>(function.apply(first.get(), second.get()));
            } else {
                return java.util.Optional.empty<R>();
            }
        }
        public static Mammoth.Couscous.java.util.Optional<R> map<R>(Mammoth.Couscous.java.util.OptionalInt first, Mammoth.Couscous.java.util.function.IntFunction<R> function) {
            if (first.isPresent()) {
                return java.util.Optional.of<R>(function.apply(first.getAsInt()));
            } else {
                return java.util.Optional.empty<R>();
            }
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.util {
    internal interface SupplierWithException<T, E> {
        T get();
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class NamespacePrefix {
        internal Mammoth.Couscous.java.util.Optional<string> _prefix;
        internal string _uri;
        internal NamespacePrefix(Mammoth.Couscous.java.util.Optional<string> prefix, string uri) {
            _prefix = prefix;
            _uri = uri;
        }
        public Mammoth.Couscous.java.util.Optional<string> getPrefix() {
            return _prefix;
        }
        public string getUri() {
            return _uri;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class NamespacePrefixes : java.lang.Iterable<NamespacePrefix> {
        internal Mammoth.Couscous.java.util.Map<string, NamespacePrefix> _uriToPrefix;
        internal NamespacePrefixes(Mammoth.Couscous.java.util.Map<string, NamespacePrefix> uriToPrefix) {
            _uriToPrefix = uriToPrefix;
        }
        public static NamespacePrefixes__Builder builder() {
            return new NamespacePrefixes__Builder();
        }
        public Mammoth.Couscous.java.util.Optional<NamespacePrefix> lookupUri(string uri) {
            return util.Maps.lookup<string, NamespacePrefix>(_uriToPrefix, uri);
        }
        public Mammoth.Couscous.java.util.Optional<NamespacePrefix> lookupPrefix(string prefix) {
            return lookupPrefix(java.util.Optional.of<string>(prefix));
        }
        public Mammoth.Couscous.java.util.Optional<NamespacePrefix> defaultNamespace() {
            return lookupPrefix(java.util.Optional.empty<string>());
        }
        public Mammoth.Couscous.java.util.Optional<NamespacePrefix> lookupPrefix(Mammoth.Couscous.java.util.Optional<string> prefix) {
            return util.Iterables.tryFind<NamespacePrefix>((_uriToPrefix).values(), new NamespacePrefixes__Anonymous_0(prefix));
        }
        public Mammoth.Couscous.java.util.Iterator<NamespacePrefix> iterator() {
            return ((_uriToPrefix).values()).iterator();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class NamespacePrefixes__Builder {
        internal Mammoth.Couscous.java.util.Map<string, NamespacePrefix> _uriToPrefix;
        internal NamespacePrefixes__Builder() {
            _uriToPrefix = new Mammoth.Couscous.java.util.HashMap<string, NamespacePrefix>();
        }
        public NamespacePrefixes__Builder put(string prefix, string uri) {
            (_uriToPrefix).put(uri, new NamespacePrefix(java.util.Optional.of<string>(prefix), uri));
            return this;
        }
        public NamespacePrefixes__Builder defaultPrefix(string uri) {
            (_uriToPrefix).put(uri, new NamespacePrefix(java.util.Optional.empty<string>(), uri));
            return this;
        }
        public NamespacePrefixes build() {
            return new NamespacePrefixes(_uriToPrefix);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class NamespacePrefixes__Anonymous_0 : Mammoth.Couscous.java.util.function.Predicate<NamespacePrefix> {
        internal Mammoth.Couscous.java.util.Optional<string> _prefix;
        internal NamespacePrefixes__Anonymous_0(Mammoth.Couscous.java.util.Optional<string> prefix) {
            _prefix = prefix;
        }
        public bool test(NamespacePrefix @namespace) {
            return (@namespace.getPrefix()).equals(_prefix);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class NullXmlElement : XmlElementLike {
        internal static XmlElementLike _INSTANCE;
        static NullXmlElement() {
            _INSTANCE = new NullXmlElement();
        }
        public bool hasChild(string name) {
            return false;
        }
        public Mammoth.Couscous.java.util.Optional<XmlElement> findChild(string name) {
            return java.util.Optional.empty<XmlElement>();
        }
        public XmlElementLike findChildOrEmpty(string name) {
            return this;
        }
        public Mammoth.Couscous.java.util.Optional<string> getAttributeOrNone(string name) {
            return java.util.Optional.empty<string>();
        }
        public Mammoth.Couscous.java.util.List<XmlNode> getChildren() {
            return util.Lists.list<XmlNode>();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class XmlElement : XmlNode, XmlElementLike {
        internal string _name;
        internal Mammoth.Couscous.java.util.Map<string, string> _attributes;
        internal Mammoth.Couscous.java.util.List<XmlNode> _children;
        internal XmlElement(string name, Mammoth.Couscous.java.util.Map<string, string> attributes, Mammoth.Couscous.java.util.List<XmlNode> children) {
            _name = name;
            _attributes = attributes;
            _children = children;
        }
        public string getName() {
            return _name;
        }
        public Mammoth.Couscous.java.util.Map<string, string> getAttributes() {
            return _attributes;
        }
        public string getAttribute(string name) {
            return (getAttributeOrNone(name)).orElseThrow<java.lang.RuntimeException>(new XmlElement__Anonymous_0(name));
        }
        public Mammoth.Couscous.java.util.Optional<string> getAttributeOrNone(string name) {
            return util.Maps.lookup<string, string>(_attributes, name);
        }
        public string innerText() {
            return java.lang.String.join("", util.Iterables.lazyMap<XmlNode, string>(_children, new XmlElement__Anonymous_1()));
        }
        public T accept<T>(XmlNodeVisitor<T> visitor) {
            return visitor.visit(this);
        }
        public Mammoth.Couscous.java.util.List<XmlNode> getChildren() {
            return _children;
        }
        public string toString() {
            return ((((("XmlElement(name=" + _name) + ", attributes=") + _attributes) + ", children=") + _children) + ")";
        }
        public XmlElementList findChildren(string name) {
            return new XmlElementList(util.Lists.toList<XmlElement>(findChildrenIterable(name)));
        }
        public Mammoth.Couscous.java.util.Optional<XmlElement> findChild(string name) {
            return util.Iterables.getFirst<XmlElement>(findChildrenIterable(name));
        }
        public bool hasChild(string name) {
            return ((findChildrenIterable(name)).iterator()).hasNext();
        }
        public XmlElementLike findChildOrEmpty(string name) {
            return util.Iterables.getFirst<XmlElementLike>(findChildrenIterable(name), NullXmlElement._INSTANCE);
        }
        public java.lang.Iterable<XmlElement> findChildrenIterable(string name) {
            return util.Iterables.lazyFilter<XmlElement>(util.Iterables.lazyFilter<XmlNode, XmlElement>(_children, typeof(XmlElement)), new XmlElement__Anonymous_2(name));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class XmlElement__Anonymous_0 : Mammoth.Couscous.java.util.function.Supplier<java.lang.RuntimeException> {
        internal string _name;
        internal XmlElement__Anonymous_0(string name) {
            _name = name;
        }
        public java.lang.RuntimeException get() {
            return new java.lang.RuntimeException(("Element has no '" + _name) + "' attribute");
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class XmlElement__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<XmlNode, string> {
        public string apply(XmlNode arg0) {
            return arg0.innerText();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class XmlElement__Anonymous_2 : Mammoth.Couscous.java.util.function.Predicate<XmlElement> {
        internal string _name;
        internal XmlElement__Anonymous_2(string name) {
            _name = name;
        }
        public bool test(XmlElement child) {
            return (child.getName()).Equals(_name);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal interface XmlElementLike {
        bool hasChild(string name);
        Mammoth.Couscous.java.util.Optional<XmlElement> findChild(string name);
        XmlElementLike findChildOrEmpty(string name);
        Mammoth.Couscous.java.util.Optional<string> getAttributeOrNone(string name);
        Mammoth.Couscous.java.util.List<XmlNode> getChildren();
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class XmlElementList : java.lang.Iterable<XmlElement> {
        internal Mammoth.Couscous.java.util.List<XmlElement> _elements;
        internal XmlElementList(Mammoth.Couscous.java.util.List<XmlElement> elements) {
            _elements = elements;
        }
        public Mammoth.Couscous.java.util.Iterator<XmlElement> iterator() {
            return (_elements).iterator();
        }
        public XmlElementList findChildren(string name) {
            return new XmlElementList(util.Lists.eagerFlatMap<XmlElement, XmlElement>(_elements, new XmlElementList__Anonymous_0(name)));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class XmlElementList__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<XmlElement, java.lang.Iterable<XmlElement>> {
        internal string _name;
        internal XmlElementList__Anonymous_0(string name) {
            _name = name;
        }
        public java.lang.Iterable<XmlElement> apply(XmlElement element) {
            return element.findChildren(_name);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal interface XmlNode {
        string innerText();
        T accept<T>(XmlNodeVisitor<T> visitor);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal interface XmlNodeVisitor<T> {
        T visit(XmlElement element);
        T visit(XmlTextNode textNode);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class XmlNodes {
        public static XmlElement element(string name) {
            return element(name, util.Lists.list<XmlNode>());
        }
        public static XmlElement element(string name, Mammoth.Couscous.java.util.Map<string, string> attributes) {
            return element(name, attributes, util.Lists.list<XmlNode>());
        }
        public static XmlElement element(string name, Mammoth.Couscous.java.util.List<XmlNode> children) {
            return element(name, util.Maps.map<string, string>(), children);
        }
        public static XmlElement element(string name, Mammoth.Couscous.java.util.Map<string, string> attributes, Mammoth.Couscous.java.util.List<XmlNode> children) {
            return new XmlElement(name, attributes, children);
        }
        public static XmlTextNode text(string value) {
            return new XmlTextNode(value);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml {
    internal class XmlTextNode : XmlNode {
        internal string _value;
        internal XmlTextNode(string value) {
            _value = value;
        }
        public string getValue() {
            return _value;
        }
        public string innerText() {
            return _value;
        }
        public T accept<T>(XmlNodeVisitor<T> visitor) {
            return visitor.visit(this);
        }
        public string toString() {
            return ("XmlTextNode(value=" + _value) + ")";
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml.parsing {
    internal class ElementName {
        internal string _uri;
        internal string _localName;
        internal ElementName(string uri, string localName) {
            _uri = uri;
            _localName = localName;
        }
        public string getUri() {
            return _uri;
        }
        public string getLocalName() {
            return _localName;
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml.parsing {
    internal interface SimpleSaxHandler {
        void startElement(ElementName name, Mammoth.Couscous.java.util.Map<ElementName, string> attributes);
        void endElement();
        void characters(string @string);
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml.parsing {
    internal class XmlElementBuilder {
        internal string _name;
        internal Mammoth.Couscous.java.util.Map<string, string> _attributes;
        internal Mammoth.Couscous.java.util.List<XmlNode> _children;
        internal XmlElementBuilder(string name, Mammoth.Couscous.java.util.Map<string, string> attributes) {
            _name = name;
            _attributes = attributes;
            _children = new Mammoth.Couscous.java.util.ArrayList<XmlNode>();
        }
        public XmlElement build() {
            return new XmlElement(_name, _attributes, _children);
        }
        public void addChild(XmlNode node) {
            (_children).add(node);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml.parsing {
    internal class XmlParser {
        internal NamespacePrefixes _namespaces;
        internal XmlParser(NamespacePrefixes namespaces) {
            _namespaces = namespaces;
        }
        public XmlElement parseStream(java.io.InputStream inputStream) {
            XmlParser__NodeGenerator nodeGenerator = create_NodeGenerator();
            SimpleSax.parseStream(inputStream, nodeGenerator);
            return nodeGenerator.getRoot();
        }
        public XmlElement parseString(string value) {
            XmlParser__NodeGenerator nodeGenerator = create_NodeGenerator();
            SimpleSax.parseString(value, nodeGenerator);
            return nodeGenerator.getRoot();
        }
        public XmlParser__NodeGenerator create_NodeGenerator() {
            return new XmlParser__NodeGenerator(this);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml.parsing {
    internal class XmlParser__NodeGenerator : SimpleSaxHandler {
        internal Mammoth.Couscous.java.util.Deque<XmlElementBuilder> _elementStack;
        internal XmlParser _this_org__zwobble__mammoth__internal__xml__parsing__XmlParser;
        internal XmlParser__NodeGenerator(XmlParser this_org__zwobble__mammoth__internal__xml__parsing__XmlParser) {
            _this_org__zwobble__mammoth__internal__xml__parsing__XmlParser = this_org__zwobble__mammoth__internal__xml__parsing__XmlParser;
            _elementStack = new Mammoth.Couscous.java.util.ArrayDeque<XmlElementBuilder>();
        }
        public XmlElement getRoot() {
            return ((_elementStack).getFirst()).build();
        }
        public void startElement(ElementName name, Mammoth.Couscous.java.util.Map<ElementName, string> attributes) {
            Mammoth.Couscous.java.util.Map<string, string> simpleAttributes = util.Maps.eagerMapKeys<ElementName, string, string>(attributes, new XmlParser__Anonymous_0(this));
            XmlElementBuilder element = new XmlElementBuilder(readName(name), simpleAttributes);
            (_elementStack).add(element);
        }
        public string readName(ElementName name) {
            if (util.Strings.isNullOrEmpty(name.getUri())) {
                return name.getLocalName();
            } else {
                return ((((_this_org__zwobble__mammoth__internal__xml__parsing__XmlParser)._namespaces).lookupUri(name.getUri())).map<string>(new XmlParser__Anonymous_2(name))).orElseGet(new XmlParser__Anonymous_3(name));
            }
        }
        public void endElement() {
            if ((_elementStack).size() > 1) {
                XmlElementBuilder element = (_elementStack).removeLast();
                ((_elementStack).getLast()).addChild(element.build());
            }
        }
        public void characters(string @string) {
            ((_elementStack).getLast()).addChild(new XmlTextNode(@string));
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml.parsing {
    internal class XmlParser__Anonymous_0 : Mammoth.Couscous.java.util.function.Function<ElementName, string> {
        internal XmlParser__NodeGenerator _this_org__zwobble__mammoth__internal__xml__parsing__XmlParser__NodeGenerator;
        internal XmlParser__Anonymous_0(XmlParser__NodeGenerator this_org__zwobble__mammoth__internal__xml__parsing__XmlParser__NodeGenerator) {
            _this_org__zwobble__mammoth__internal__xml__parsing__XmlParser__NodeGenerator = this_org__zwobble__mammoth__internal__xml__parsing__XmlParser__NodeGenerator;
        }
        public string apply(ElementName arg0) {
            return (_this_org__zwobble__mammoth__internal__xml__parsing__XmlParser__NodeGenerator).readName(arg0);
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml.parsing {
    internal class XmlParser__Anonymous_1 : Mammoth.Couscous.java.util.function.Function<string, string> {
        public string apply(string prefix) {
            return prefix + ":";
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml.parsing {
    internal class XmlParser__Anonymous_2 : Mammoth.Couscous.java.util.function.Function<NamespacePrefix, string> {
        internal ElementName _name;
        internal XmlParser__Anonymous_2(ElementName name) {
            _name = name;
        }
        public string apply(NamespacePrefix @namespace) {
            return ((@namespace.getPrefix()).map<string>(new XmlParser__Anonymous_1())).orElse("") + (_name).getLocalName();
        }
    }
}

namespace Mammoth.Couscous.org.zwobble.mammoth.@internal.xml.parsing {
    internal class XmlParser__Anonymous_3 : Mammoth.Couscous.java.util.function.Supplier<string> {
        internal ElementName _name;
        internal XmlParser__Anonymous_3(ElementName name) {
            _name = name;
        }
        public string get() {
            return (("{" + (_name).getUri()) + "}") + (_name).getLocalName();
        }
    }
}

