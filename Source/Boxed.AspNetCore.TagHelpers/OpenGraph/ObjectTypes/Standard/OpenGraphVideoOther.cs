namespace Boxed.AspNetCore.TagHelpers.OpenGraph
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    /// <summary>
    /// This object type represents a generic video, and contains references to the actors and other professionals involved in its production. For
    /// specific types of video content, use the video.movie or video.tv_show object types. This type is for any other type of video content not
    /// represented elsewhere (eg. trailers, music videos, clips, news segments etc.). This object type is part of the Open Graph standard.
    /// See http://ogp.me/
    /// See https://developers.facebook.com/docs/reference/opengraph/object-type/video.other/.
    /// </summary>
    [HtmlTargetElement(
        "open-graph-video-other",
        Attributes = TitleAttributeName + "," + MainImageAttributeName,
        TagStructure = TagStructure.WithoutEndTag)]
    public class OpenGraphVideoOther : OpenGraphMetadata
    {
        private const string ActorsAttributeName = "actors";
        private const string DirectorUrlsAttributeName = "director-urls";
        private const string DurationAttributeName = "duration";
        private const string ReleaseDateAttributeName = "release-date";
        private const string TagsAttributeName = "tags";
        private const string WriterUrlsAttributeName = "writer-urls";

        /// <summary>
        /// Gets or sets the actors in the video.
        /// </summary>
        [HtmlAttributeName(ActorsAttributeName)]
        public IEnumerable<OpenGraphActor> Actors { get; set; }

        /// <summary>
        /// Gets or sets the URL's to the pages about the directors. This URL's must contain profile meta tags <see cref="OpenGraphProfile"/>.
        /// </summary>
        [HtmlAttributeName(DirectorUrlsAttributeName)]
        public IEnumerable<string> DirectorUrls { get; set; }

        /// <summary>
        /// Gets or sets the duration of the video in seconds.
        /// </summary>
        [HtmlAttributeName(DurationAttributeName)]
        public int? Duration { get; set; }

        /// <summary>
        /// Gets the namespace of this open graph type.
        /// </summary>
        public override string Namespace => "video: http://ogp.me/ns/video#";

        /// <summary>
        /// Gets or sets the release date of the video.
        /// </summary>
        [HtmlAttributeName(ReleaseDateAttributeName)]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the tag words associated with the video.
        /// </summary>
        [HtmlAttributeName(TagsAttributeName)]
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets the type of your object. Depending on the type you specify, other properties may also be required.
        /// </summary>
        public override OpenGraphType Type => OpenGraphType.VideoOther;

        /// <summary>
        /// Gets or sets the URL's to the pages about the writers. This URL's must contain profile meta tags <see cref="OpenGraphProfile"/>.
        /// </summary>
        [HtmlAttributeName(WriterUrlsAttributeName)]
        public IEnumerable<string> WriterUrls { get; set; }

        /// <summary>
        /// Appends a HTML-encoded string representing this instance to the <paramref name="stringBuilder"/> containing the Open Graph meta tags.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        public override void ToString(StringBuilder stringBuilder)
        {
            base.ToString(stringBuilder);

            if (this.Actors != null)
            {
                foreach (var actor in this.Actors)
                {
                    stringBuilder.AppendMetaPropertyContentIfNotNull("video:actor", actor.ActorUrl);
                    stringBuilder.AppendMetaPropertyContentIfNotNull("video:actor:role", actor.Role);
                }
            }

            stringBuilder.AppendMetaPropertyContentIfNotNull("video:director", this.DirectorUrls);
            stringBuilder.AppendMetaPropertyContentIfNotNull("video:writer", this.WriterUrls);
            stringBuilder.AppendMetaPropertyContentIfNotNull("video:duration", this.Duration);
            stringBuilder.AppendMetaPropertyContentIfNotNull("video:release_date", this.ReleaseDate);
            stringBuilder.AppendMetaPropertyContentIfNotNull("video:tag", this.Tags);
        }
    }
}
